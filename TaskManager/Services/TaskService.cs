using TaskManager.Models;
using TaskManager.Repositories.Interfaces;
using TaskManager.Services.Interfaces;

namespace TaskManager.Services;

public sealed class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    
    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    
    public Task<IEnumerable<TaskItem>> GetAllTasksAsync() => _taskRepository.GetAllTasks();

    public Task<TaskItem> GetTaskByIdAsync(int id) => _taskRepository.GetTaskById(id);

    public Task AddTaskAsync(TaskItem task) => _taskRepository.InsertTask(task);

    public Task<bool> UpdateTaskAsync(int id, TaskItem task) => _taskRepository.UpdateTask(id, task);

    public Task DeleteTaskAsync(int id) => _taskRepository.DeleteTask(id);
}