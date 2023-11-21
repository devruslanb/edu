using System.Collections.Concurrent;
using sandbox.Services.Interface;

namespace sandbox.Services.Impl;

public class TaskService : ITaskService
{
    private readonly ConcurrentDictionary<string, int> _tasksProgress = new ConcurrentDictionary<string, int>();

    public string StartTask()
    {
        var taskId = Guid.NewGuid().ToString();
        _tasksProgress.TryAdd(taskId, 0);

        // Запускаем задачу асинхронно
        Task.Run(() =>
        {
            for (var i = 0; i <= 1000; i++)
            {
                // Имитация работы
                Task.Delay(100).Wait();
                _tasksProgress[taskId] = i; // Обновляем прогресс
            }
        });

        return taskId;
    }

    public int GetTaskProgress(string taskId)
    {
        _tasksProgress.TryGetValue(taskId, out var progress);
        return progress;
    }
}