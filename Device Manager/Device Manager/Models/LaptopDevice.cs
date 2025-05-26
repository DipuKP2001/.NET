using Device_Manager.Interfaces;

namespace Device_Manager.Models;

public class LaptopDevice : IDevice
{
    public string GetDeviceType()
    {
        return "Laptop";
    }
}