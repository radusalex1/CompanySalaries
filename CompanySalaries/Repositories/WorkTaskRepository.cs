using CompanySalaries.DBContext;
using CompanySalaries.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanySalaries.Repositories
{
    public class WorkTaskRepository : BaseRepository, IWorkTaskRepository
    {

        public WorkTaskRepository(CompanyContext context) : base(context)
        {

        }

        public void AddWorkTask(WorkTask WorkTask)
        {
            _companyContext.WorkTasks.Add(WorkTask);
            _companyContext.SaveChanges();
        }

        public IEnumerable<WorkTask> GetAllWorkTasks()
        {
            return _companyContext.WorkTasks
                .Include(o=>o.TypeOfWorkTask)
                .Include(o=>o.Project)
                .ToList();
        }

        public WorkTask GetWorkTaskById(int id)
        {
            return _companyContext.WorkTasks
                .Include(x => x.TypeOfWorkTask)
                .FirstOrDefault(x => x.Id == id);
        }

        public WorkTask GetWorkTaskByName(string name)
        {
            return _companyContext.WorkTasks
                .Include(o => o.TypeOfWorkTask)
                .Include(o => o.Project)
                .Where(o=>o.Name==name).FirstOrDefault();
        }

        public bool IfExists(WorkTask workTask)
        {
            return _companyContext.WorkTasks.Any(x => x.Project.Id == workTask.Project.Id && x.Name == workTask.Name);
        }
    }
}
