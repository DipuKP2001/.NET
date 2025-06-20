﻿using System.ComponentModel.DataAnnotations;

namespace LogTracker.Models;

public sealed class Log
{
    [Key]
    public int Id { get; set; }
    
    public string Message { get; set; }
    
    public string Severity { get; set; }
    
    public DateTime Time => DateTime.UtcNow;
}