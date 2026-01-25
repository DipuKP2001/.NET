using TaskManager.Models;
using TaskManager.Repositories.Interfaces;

namespace TaskManager.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly List<TaskItem> _tasks = new ()
    {
        new TaskItem { Id = 1, Title = "Initial Task", IsCompleted =  false }
    };
    
    public Task<IEnumerable<TaskItem>> GetAllTasks()
    {
        return Task.FromResult(_tasks.AsEnumerable());
    }

    public Task<TaskItem?> GetTaskById(int id)
    {
        return Task.FromResult(_tasks.FirstOrDefault(t => t.Id == id));
    }

    public Task InsertTask(TaskItem item)
    {
        item.Id = _tasks.Max(t => t.Id) + 1;
        _tasks.Add(item);
        return Task.CompletedTask;
    }

    public Task<bool> UpdateTask(int id, TaskItem task)
    {
        var current = _tasks.FirstOrDefault(t => t.Id == id);
        if (current == null)
        {
            return Task.FromResult(false);
        }
        
        if(!string.IsNullOrWhiteSpace(task.Title))
        {
            current.Title = task.Title;
        }
        
        current.IsCompleted = task.IsCompleted;
        
        return Task.FromResult(true);
    }

    public Task DeleteTask(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            _tasks.Remove(task);
        }
        
        return Task.CompletedTask;
    }
}