using CompanySalaries.DBContext;
using CompanySalaries.Models;

namespace CompanySalaries.Repositories
{
    public class TaskWorkRepository :BaseRepository,ITaskWorkRepository
    {
        public TaskWorkRepository(CompanyContext companyContext):base(companyContext)   
        {

        }
        public void AddTask(TaskWork taskWork)
        {
            _companyContext.TasksWork.Add(taskWork);
            _companyContext.SaveChanges();
        }

        public IEnumerable<TaskWork> GetAllTasks()
        {
            return _companyContext.TasksWork.ToList();
        }
    }
}
