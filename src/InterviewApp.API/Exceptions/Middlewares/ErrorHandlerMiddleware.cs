using System.Net;
using InterviewApp.API.Exceptions.Abstractions;

namespace InterviewApp.API.Exceptions.Middlewares;

internal sealed class ErrorHandlerMiddleware : IMiddleware
{
    private readonly IExceptionToResponseMapper _mapper;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    public ErrorHandlerMiddleware(
        IExceptionToResponseMapper mapper,
        ILogger<ErrorHandlerMiddleware> logger
    )
    {
        _mapper = mapper;
        _logger = logger;
    }

    public async Task InvokeAsync(
        HttpContext ctx,
        RequestDelegate next
    )
    {
        try
        {
            await next(ctx);
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                ex.Message
            );

            await HandleErrorAsync(
                ctx,
                ex
            );
        }
    }

    private async Task HandleErrorAsync(
        HttpContext ctx,
        Exception ex
    )
    {
        var errorResponse = _mapper.Map(ex);
        ctx.Response.StatusCode = (int)(errorResponse?.StatusCode ?? HttpStatusCode.InternalServerError);
        var res = errorResponse?.Response;
        if (res is null)
            return;

        await ctx.Response.WriteAsJsonAsync(res);
    }
}