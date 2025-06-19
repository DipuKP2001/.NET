using LogTracker.Implementation.Services;
using LogTracker.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LogTracker.Implementation;

public static class DependencyInjection
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ILogService, LogService>();
        services.AddSingleton<ILogFlushService, LogFlushService>();
        
        return services;
    }
}