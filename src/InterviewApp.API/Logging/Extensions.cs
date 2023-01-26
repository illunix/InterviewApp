using InterviewApp.API.Options;
using InterviewApp.Core;
using Serilog;
using Serilog.Events;
using Serilog.Filters;

namespace InterviewApp.API.Extensions;

internal static class LoggingExtensions
{
    private const string _consoleOutputTemplate = "{Timestamp:HH:mm:ss} [{Level:u3}] {Message}{NewLine}{Exception}";
    private const string _serilogSectionName = "serilog";

    public static WebApplicationBuilder AddLogging(
        this WebApplicationBuilder builder,
        Action<LoggerConfiguration>? configure = null
    )
    {
        builder.Host.AddLogging(configure);
        return builder;
    }

    private static IHostBuilder AddLogging(
        this IHostBuilder builder,
        Action<LoggerConfiguration>? configure = null
    )
        => builder.UseSerilog((
            ctx,
            loggerConfiguration
        ) =>
        {
            var loggerOptions = ctx.Configuration.BindOptions<SerilogOptions>(_serilogSectionName);

            Configure(
                loggerOptions,
                loggerConfiguration,
                ctx.HostingEnvironment.EnvironmentName
            );

            configure?.Invoke(loggerConfiguration);
        });

    private static void Configure(
        SerilogOptions serilogOptions,
        LoggerConfiguration loggerConfiguration,
        string environmentName
    )
    {
        var level = GetLogEventLevel(serilogOptions.Level);

        loggerConfiguration.Enrich.FromLogContext()
            .MinimumLevel.Is(level)
            .Enrich.WithProperty("Environment", environmentName);

        foreach (var (
            key,
            value
        ) in serilogOptions.Tags)
            loggerConfiguration.Enrich.WithProperty(
                key,
                value
            );

        foreach (var (
            key,
            value
        ) in serilogOptions.Overrides)
        {
            var logLevel = GetLogEventLevel(value);
            loggerConfiguration.MinimumLevel.Override(
                key,
                logLevel
            );
        }

        serilogOptions.ExcludePaths?.ToList().ForEach(q => loggerConfiguration.Filter
            .ByExcluding(Matching.WithProperty<string>(
                "RequestPath",
                q => q.EndsWith(q)
            ))
        );

        serilogOptions.ExcludeProperties?.ToList().ForEach(q => loggerConfiguration.Filter
            .ByExcluding(Matching.WithProperty(q))
        );

        Configure(
            loggerConfiguration,
            serilogOptions
        );
    }

    private static void Configure(
        LoggerConfiguration loggerConfiguration,
        SerilogOptions options
    )
    {
        var consoleOptions = options.Console;
        var seqOptions = options.Seq;

        if (consoleOptions.Enabled)
            loggerConfiguration.WriteTo.Console(outputTemplate: _consoleOutputTemplate);

        if (seqOptions.Enabled)
            loggerConfiguration.WriteTo.Seq(
                seqOptions.Url,
                apiKey: seqOptions.ApiKey
            );
    }

    private static LogEventLevel GetLogEventLevel(string level)
        => Enum.TryParse<LogEventLevel>(
            level,
            true,
            out var logLevel
        )
            ? logLevel
            : LogEventLevel.Information;
}
