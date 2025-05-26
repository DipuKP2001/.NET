using Device_Manager.Interfaces;

namespace Device_Manager.Models;

public class MobileDevice : IDevice
{
    public string GetDeviceType()
    {
        return "Mobile";
    }
}