using LogTracker.Models;

namespace LogTracker.Services;

public interface ILogService
{
    Task<IEnumerable<Log>> GetLogsAsync();
    
    void AddLogSync(Log log);
    
    Task AddLogAsync(Log log);
    
}