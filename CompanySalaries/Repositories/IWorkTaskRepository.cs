using CompanySalaries.Models;

namespace CompanySalaries.Repositories
{
    public interface IWorkTaskRepository
    {
        public void AddWorkTask(WorkTask WorkTask);
        public IEnumerable<WorkTask> GetAllWorkTasks();
        public WorkTask GetWorkTaskByName(string name);
        public WorkTask GetWorkTaskById(int id);
        public bool IfExists(WorkTask workTask);
    }
}
