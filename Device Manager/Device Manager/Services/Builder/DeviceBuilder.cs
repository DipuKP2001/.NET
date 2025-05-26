using Device_Manager.Interfaces;
using DeviceManager.Models;

namespace Device_Manager.Services.Builder;

public class DeviceBuilder : IDeviceBuilder
{
    private readonly Device _device = new();

    public IDeviceBuilder SetId(int id)
    {
        _device.Id = id;
        return this;
    }

    public IDeviceBuilder SetName(string name)
    {
        _device.Name = name;
        return this;
    }

    public IDeviceBuilder SetPlatform(string platform)
    {
        _device.Platform = platform;
        return this;
    }

    public Device BuildDevice()
    {
        return _device;
    }
}