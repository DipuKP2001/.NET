using Device_Manager.Interfaces;
using Device_Manager.Services;
using Device_Manager.Services.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Device_Manager;
    
public static class DependencyInjection
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IDeviceBuilder, DeviceBuilder>();
        
        services.AddSingleton<IDeviceService, DeviceService>();
        
        services.AddSingleton<SingletonGuidGenerator>();
        services.AddScoped<ScopedGuidGenerator>();
        services.AddTransient<TransientGuidGenerator>();
        
        return services;
    }
}