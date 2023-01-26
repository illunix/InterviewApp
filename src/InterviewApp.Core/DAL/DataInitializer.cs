using InterviewApp.Core.DAL.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InterviewApp.Core.DAL;

internal sealed class DataInitializer : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<DataInitializer> _logger;

    public DataInitializer(
        IServiceProvider serviceProvider,
        ILogger<DataInitializer> logger
    )
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken ct)
    {
        await using var scope = _serviceProvider.CreateAsyncScope();
        var initializers = scope.ServiceProvider.GetServices<IDataInitializer>();
        foreach (var initializer in initializers)
        {
            try
            {
                _logger.LogInformation($"Running the initializer: {initializer.GetType().Name}...");
                await initializer.Init();
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    ex.Message
                );
            }
        }
    }

    public Task StopAsync(CancellationToken ct)
        => Task.CompletedTask;
}