using LogTracker.Models;

namespace LogTracker.Services;

public interface ILogService
{
    Task LogAsync(Log log);
    
    Task<IEnumerable<Log>> GetLogsAsync();
}