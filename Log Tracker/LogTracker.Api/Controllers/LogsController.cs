using System.Diagnostics;
using LogTracker.Models;
using LogTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace LogTracker.Api.Controllers;

[ApiController]
[Route("api/logs")]
public sealed class LogsController : ControllerBase
{
    private const int TotalLogsCount = 5000;
    
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
        await _logService.AddLogAsync(log);
        return Ok("Logged.");
    }

    [HttpPost]
    [Route("sync/bulk")]
    public IActionResult SyncBulk()
    {
        var watch = Stopwatch.StartNew();

        for (var i = 0; i < TotalLogsCount; i++)
        {
            var log = new Log
            {
                Message = $"Log {i}",
                Severity = $"Severity {i}"
            };
            
            _logService.AddLogSync(log);
        }
        
        watch.Stop();
        return Ok($"Synchronous Logs, Total Time: {watch.ElapsedMilliseconds} ms");
    }

    [HttpPost]
    [Route("async/bulk")]
    public async Task<IActionResult> AsyncBulk()
    {
        var watch = Stopwatch.StartNew();
        
        for (var i = 0; i < TotalLogsCount; i++)
        {
            var log = new Log
            {
                Message = $"Log {i}",
                Severity = $"Severity {i}"
            };
            
            await _logService.AddLogAsync(log);
        }
        
        watch.Stop();
        return Ok($"Asynchronous Logs, Total Time: {watch.ElapsedMilliseconds} ms");
    }

    [HttpPost]
    [Route("async/bulk-parallel")]
    public async Task<IActionResult> AsyncBulkParallel()
    {
        var watch = Stopwatch.StartNew();

        var tasks = Enumerable.Range(0, TotalLogsCount)
            .Select(i =>
            {
                var log = new Log
                {
                    Message = $"Log {i}",
                    Severity = $"Severity {i}"
                };

                return _logService.AddLogAsync(log);
            });

        await Task.WhenAll(tasks);
        
        watch.Stop();
        return Ok($"Asynchronous Parallel Logs, Total Time: {watch.ElapsedMilliseconds} ms");
    }
}
