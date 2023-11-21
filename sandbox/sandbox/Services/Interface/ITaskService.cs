namespace sandbox.Services.Interface;

public interface ITaskService
{
    string StartTask();
    int GetTaskProgress(string taskId);
}
