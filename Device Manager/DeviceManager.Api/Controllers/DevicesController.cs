using Device_Manager.Services;
using DeviceManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManager.Api.Controllers;

[ApiController]
[Route("api/devices")]
public class DevicesController : ControllerBase
{
    private readonly IDeviceService _deviceService;

    public DevicesController(IDeviceService deviceService)
    {
        _deviceService = deviceService ?? throw new ArgumentNullException(nameof(deviceService));
    }

    [HttpGet]
    public List<Device> GetDevices()
    {
        var devices = _deviceService.GetAll();
        
        return devices;
    }
}