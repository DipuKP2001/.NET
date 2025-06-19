using LogTracker.Implementation.Data;
using LogTracker.Models;
using LogTracker.Services;
using Microsoft.Extensions.DependencyInjection;
using Timer = System.Timers.Timer;

namespace LogTracker.Implementation.Services;

public sealed class LogFlushService: ILogFlushService
{
    private static readonly List<Log> _logBuffer = [];
    private static readonly Lock _lock = new();
    private static Timer _timer;

    private const int FlushTimeDuration = 5000;
    
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public LogFlushService(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;

        StartTimer();
    }
    
    public void AddLog(Log log)
    {
        lock (_lock)
        {
            _logBuffer.Add(log);
        }
    }

    private async Task FlushLogsAsync()
    {
        List<Log> logsToFlush;

        lock (_lock)
        {
            if (_logBuffer.Count == 0)
            {
                return;
            }
            
            logsToFlush = _logBuffer;
            _logBuffer.Clear();
        }
        
        using var scope = _serviceScopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<LogDbContext>();
        
        await context.Logs.AddRangeAsync(logsToFlush);
        await context.SaveChangesAsync();
        
        Console.WriteLine($"Flushed {logsToFlush.Count} logs at {DateTime.Now}");
    }

    private void StartTimer()
    {
        _timer = new Timer(FlushTimeDuration);
        _timer.Elapsed += async (sender, args) => await FlushLogsAsync();
        _timer.AutoReset = true;
        _timer.Enabled = true;
    }
}