using LogTracker.Implementation.Data;
using LogTracker.Models;
using LogTracker.Services;
using Microsoft.EntityFrameworkCore;

namespace LogTracker.Implementation.Services;

public class LogService : ILogService
{
    private readonly LogDbContext _context;

    public LogService(LogDbContext context)
    {
        _context = context;
    }

    public void AddLogSync(Log log)
    {
        _context.Logs.Add(log);
        
        _context.SaveChanges();
    }

    public async Task AddLogAsync(Log log)
    {
        _context.Logs.Add(log);
        
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Log>> GetLogsAsync()
    {
        return await _context.Logs.ToListAsync();
    }
}