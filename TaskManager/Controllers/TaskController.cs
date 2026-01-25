using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Services.Interfaces;

namespace TaskManager.Controllers;

[ApiController]
[Route("tasks")]
public sealed class TaskController : ControllerBase
{
    private readonly ITaskService _service;

    public TaskController(ITaskService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllTasksAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskById(int id)
    {
        var task = await _service.GetTaskByIdAsync(id);
        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] TaskItem task)
    {
        await _service.AddTaskAsync(task);
        return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] TaskItem task)
    {
        if (id != task.Id)
        {
            return BadRequest("Mismatched task id");
        }
        
        var updated = await _service.UpdateTaskAsync(id, task);
        if(!updated) return NotFound();

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteTaskAsync(id);
        return NoContent();
    }
}