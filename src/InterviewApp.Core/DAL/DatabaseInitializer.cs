using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InterviewApp.Core.DAL;

internal sealed class DatabaseInitializer<T> : IHostedService where T : DbContext
{
    private readonly IServiceProvider _serviceProvider;

    public DatabaseInitializer(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public async Task StartAsync(CancellationToken ct)
    {
        await using var scope = _serviceProvider.CreateAsyncScope();
        var dbContext = (DbContext)scope.ServiceProvider.GetRequiredService<T>();
        await dbContext.Database.MigrateAsync(ct);
    }

    public Task StopAsync(CancellationToken ct)
        => Task.CompletedTask;
}
