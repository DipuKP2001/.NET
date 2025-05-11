using DeviceManager.Models;

namespace Device_Manager.Services;

public interface IDeviceService
{
    public List<Device> GetAll();
}