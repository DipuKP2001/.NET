using DeviceManager.Models;

namespace Device_Manager.Services;

public class DeviceService : IDeviceService
{
    public List<Device> GetAll()
    {
        return
        [
            new Device { Id = 1, Name = "Device 1" },
            new Device { Id = 2, Name = "Device 2" }
        ];
    }
}