using TaskManager.Models;

namespace TaskManager.Services.Interfaces;

public interface ITaskService
{
    Task<IEnumerable<TaskItem>> GetAllTasksAsync();
    
    Task<TaskItem> GetTaskByIdAsync(int id);
    
    Task AddTaskAsync(TaskItem task);
    
    Task<bool> UpdateTaskAsync(int id, TaskItem task);
    
    Task DeleteTaskAsync(int id);
}