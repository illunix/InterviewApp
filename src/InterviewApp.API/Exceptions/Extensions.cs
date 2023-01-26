using InterviewApp.API.Exceptions.Abstractions;
using InterviewApp.API.Exceptions.Mappers;
using InterviewApp.API.Exceptions.Middlewares;

namespace InterviewApp.API.Extensions;

internal static class ErrorHandlingExtensions
{
    public static IServiceCollection AddErrorHandling(this IServiceCollection services)
        => services
            .AddSingleton<ErrorHandlerMiddleware>()
            .AddSingleton<IExceptionToResponseMapper, ExceptionToResponseMapper>();

    public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
        => app.UseMiddleware<ErrorHandlerMiddleware>();
}