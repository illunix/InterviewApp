using InterviewApp.Core.DAL.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewApp.Core.DAL;

internal static class Extensions
{
    public static IServiceCollection AddPostgres<T>(
        this IServiceCollection services,
        IConfiguration configuration
    )
        where T : DbContext
    {
        var section = configuration.GetSection("postgres");
        var options = section.BindOptions<PostgresOptions>();
        services.Configure<PostgresOptions>(section);
        if (!section.Exists())
            return services;

        services.AddDbContext<T>(q => q.UseNpgsql(options.ConnectionString));
        services.AddHostedService<DatabaseInitializer<T>>();
        services.AddHostedService<DataInitializer>();

        // Temporary fix for EF Core issue related to https://github.com/npgsql/efcore.pg/issues/2000
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        return services;
    }

    public static IServiceCollection AddInitializer<T>(this IServiceCollection services) where T :
        class,
        IDataInitializer
        => services.AddTransient<IDataInitializer, T>();
}