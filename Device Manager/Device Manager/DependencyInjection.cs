using Device_Manager.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Device_Manager;

public static class DependencyInjection
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddSingleton<IDeviceService, DeviceService>();
        
        services.AddSingleton<SingletonGuidGenerator>();
        services.AddScoped<ScopedGuidGenerator>();
        services.AddTransient<TransientGuidGenerator>();
        
        return services;
    }
}