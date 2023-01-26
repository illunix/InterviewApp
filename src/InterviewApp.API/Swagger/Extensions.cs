using InterviewApp.Core;
using Microsoft.Extensions.Options;

namespace InterviewApp.API.Swagger;

public static class Extensions
{
    public static IServiceCollection AddSwaggerDocs(
        this IServiceCollection services,
        IConfiguration config
    )
    {
        var section = config.GetSection("swagger");
        var options = section.BindOptions<SwaggerOptions>();
        services.Configure<SwaggerOptions>(section);

        if (!options.Enabled)
        {
            return services;
        }

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(q =>
        {
            q.CustomSchemaIds(q => q.FullName);
            q.SwaggerDoc(
                options.Version,
                new()
                {
                    Title = options.Title,
                    Version = options.Version
                }
            );
        });

        return services;
    }

    public static IApplicationBuilder UseSwaggerDocs(this IApplicationBuilder app)
    {
        var options = app.ApplicationServices.GetRequiredService<IOptions<SwaggerOptions>>().Value;
        if (!options.Enabled)
            return app;

        app.UseSwagger();
        app.UseSwaggerUI(q =>
        {
            q.DefaultModelExpandDepth(-1);
        });

        return app;
    }
}