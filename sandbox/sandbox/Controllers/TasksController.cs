using Microsoft.AspNetCore.Mvc;
using sandbox.Services;
using sandbox.Services.Interface;

namespace sandbox.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    // Допустим, у нас есть сервис, который выполняет задачу и отслеживает прогресс
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost]
    public IActionResult StartTask()
    {
        // Запустить задачу и получить идентификатор для отслеживания
        var taskId = _taskService.StartTask();
        return Ok(new { TaskId = taskId });
    }

    [HttpGet("{taskId}/progress")]
    public IActionResult GetTaskProgress(string taskId)
    {
        // Получить текущий прогресс задачи
        var progress = _taskService.GetTaskProgress(taskId);
        return Ok(new { Progress = progress });
    }
}