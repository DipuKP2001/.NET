using TaskManager.Models;

namespace TaskManager.Repositories.Interfaces;

public interface ITaskRepository
{
    Task<IEnumerable<TaskItem>> GetAllTasks();
    
    Task<TaskItem?> GetTaskById(int id);
    
    Task InsertTask(TaskItem task);
    
    Task<bool> UpdateTask(int id, TaskItem task);
    
    Task DeleteTask(int id);
}