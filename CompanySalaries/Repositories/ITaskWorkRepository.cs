using CompanySalaries.Models;

namespace CompanySalaries.Repositories
{
    public interface ITaskWorkRepository
    {
        public void AddTask(TaskWork taskWork);
        public IEnumerable<TaskWork> GetAllTasks();
    }
}
