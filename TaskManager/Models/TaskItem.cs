namespace TaskManager.Models;

public sealed class TaskItem
{
    public int Id { get; set; }
    
    public string Title { get; set; } = string.Empty;
    
    public bool IsCompleted { get; set; }
}