using InterviewApp.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewApp.Core.Dispatchers;

public static class Extensions
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        var asm = typeof(Extensions).Assembly;

        services.Scan(s => s.FromAssemblies(asm)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.Scan(s => s.FromAssemblies(asm)
            .AddClasses(c => c.AssignableTo(typeof(IEventHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.Scan(s => s.FromAssemblies(asm)
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }

    public static IServiceCollection AddDispatchers(this IServiceCollection services)
        => services
            .AddSingleton<IDispatcher, Dispatcher>()
            .AddSingleton<ICommandDispatcher, CommandDispatcher>()
            .AddSingleton<IEventDispatcher, EventDispatcher>()
            .AddSingleton<IQueryDispatcher, QueryDispatcher>();
}