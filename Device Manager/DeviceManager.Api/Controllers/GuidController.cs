using Device_Manager.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManager.Api.Controllers;

[ApiController]
[Route("api/guid")]
public class GuidController : ControllerBase
{
    private readonly SingletonGuidGenerator _singletonGuidGenerator;
    private readonly SingletonGuidGenerator _singletonGuidGenerator2;
    private readonly ScopedGuidGenerator _scopedGuidGenerator;
    private readonly ScopedGuidGenerator _scopedGuidGenerator2;
    private readonly TransientGuidGenerator _transientGuidGenerator;
    private readonly TransientGuidGenerator _transientGuidGenerator2;
    
    public GuidController(
        SingletonGuidGenerator singletonGuidGenerator,
        SingletonGuidGenerator singletonGuidGenerator2,
        ScopedGuidGenerator scopedGuidGenerator,
        ScopedGuidGenerator scopedGuidGenerator2,
        TransientGuidGenerator transientGuidGenerator,
        TransientGuidGenerator transientGuidGenerator2)
    {
        _singletonGuidGenerator = singletonGuidGenerator;
        _singletonGuidGenerator2 = singletonGuidGenerator2;
        _scopedGuidGenerator = scopedGuidGenerator;
        _scopedGuidGenerator2 = scopedGuidGenerator2;
        _transientGuidGenerator = transientGuidGenerator;
        _transientGuidGenerator2 = transientGuidGenerator2;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            Singleton1 = _singletonGuidGenerator.Generate(),
            Singleton2 = _singletonGuidGenerator2.Generate(),
            Scoped1 = _scopedGuidGenerator.Generate(),
            Scoped2 = _scopedGuidGenerator2.Generate(),
            Transient1 = _transientGuidGenerator.Generate(),
            Transient2 = _transientGuidGenerator2.Generate()
        });
    }
}