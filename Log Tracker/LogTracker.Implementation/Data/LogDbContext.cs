using LogTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace LogTracker.Implementation.Data;

public sealed class LogDbContext : DbContext
{
    public LogDbContext(DbContextOptions<LogDbContext> options) : base(options) {}
    
    public DbSet<Log> Logs => Set<Log>();
}