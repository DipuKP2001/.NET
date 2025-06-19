using LogTracker.Models;

namespace LogTracker.Services;

public interface ILogFlushService
{
    public void AddLog(Log log);
}