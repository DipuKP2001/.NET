using Device_Manager.Interfaces;
using Device_Manager.Models;

namespace Device_Manager.Services.Creator;

public class DeviceFactory
{
    public IDevice? CreateDevice(string type)
    {
        if (type == "Laptop")
        {
            return new LaptopDevice();
        }

        if (type == "Mobile")
        {
            return new MobileDevice();
        }
    
        return null;
    }
}