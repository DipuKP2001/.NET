using DeviceManager.Models;

namespace Device_Manager.Interfaces;

public interface IDeviceBuilder
{
    IDeviceBuilder SetId(int id);
    
    IDeviceBuilder SetName(string name);
    
    IDeviceBuilder SetPlatform(string platform);
    
    Device BuildDevice();
}