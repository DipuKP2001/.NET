using LogTracker.Models;
using LogTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace LogTracker.Api.Controllers;

[ApiController]
[Route("api/logs")]
public sealed class LogsController : ControllerBase
{
    private readonly ILogService _logService;
    
    public LogsController(ILogService logService)
    {
        _logService = logService ?? throw new ArgumentNullException(nameof(logService));
    }

    [HttpGet]
    public async Task<IEnumerable<Log>> GetAsync()
    {
        return await _logService.GetLogsAsync();
    }
    
    [HttpPost]
    public async Task<IActionResult> Log([FromBody] Log log)
    {
        await _logService.LogAsync(log);
        return Ok("Logged.");
    }
}