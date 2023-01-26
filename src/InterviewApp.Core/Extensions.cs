using InterviewApp.Core.DAL;
using InterviewApp.Core.Dispatchers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewApp.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(
        this IServiceCollection services,
        IConfiguration config
    )
        => services
            .AddHandlers()
            .AddPostgres<InterviewAppDbContext>(config)
            .AddInitializer<MoviesDataInitializer>();

    public static T BindOptions<T>(
        this IConfiguration config,
        string sectionName
    ) where T : new()
        => BindOptions<T>(config.GetSection(sectionName));

    public static T BindOptions<T>(this IConfigurationSection section) where T : new()
    {
        var options = new T();
        section.Bind(options);
        return options;
    }
}