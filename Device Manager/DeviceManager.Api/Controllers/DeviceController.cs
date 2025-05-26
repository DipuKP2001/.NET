using Device_Manager.Interfaces;
using Device_Manager.Models;
using Device_Manager.Services.Creator;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManager.Api.Controllers;

[ApiController]
[Route("api/device")]
public class DeviceController : ControllerBase
{
    private readonly IDeviceBuilder _builder;
    
    public DeviceController(IDeviceBuilder builder)
    {
        _builder = builder;
    }
    
    [HttpGet("traditional/{type}")]
    public IActionResult GetTraditional(string type)
    {
        switch (type)
        {
            case "Laptop":
            {
                var device = new LaptopDevice();
                return Ok($"Device created with type: {device.GetDeviceType()}");
            }
            case "Mobile":
            {
                var device = new MobileDevice();
                return Ok($"Device created with type: {device.GetDeviceType()}");
            }
        }

        return BadRequest("Invalid device type specified.");
    }
    
    [HttpGet("factory/{type}")]
    public IActionResult GetFactory(string type)
    {
        var deviceFactory = new DeviceFactory();
        
        var device = deviceFactory.CreateDevice(type);

        if (device == null)
        {
            return BadRequest("Invalid device type specified.");
        }
        
        return Ok($"Device created with type: {device.GetDeviceType()}");
    }

    [HttpGet("builder")]
    public IActionResult Get()
    {
        var device = _builder
            .SetId(1)
            .SetName("Laptop")
            .SetPlatform("Windows")
            .BuildDevice();
        
        return Ok(device);
    }
}