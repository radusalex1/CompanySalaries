using CompanySalaries.DBContext;
using CompanySalaries.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanySalaries.Repositories
{
    public class EmployeeTaskRepository : BaseRepository, IEmployeeTaskRepository
    {
        public EmployeeTaskRepository(CompanyContext companyContext) : base(companyContext)
        {

        }

        public void AddEmployeeTask(EmployeeTask employeeTask)
        {
           _companyContext.EmployeesTask.Add(employeeTask);
           _companyContext.SaveChanges();
        }

        public IEnumerable<EmployeeTask> GetByStartWeek(DateTime startWeek)
        {
            return _companyContext.EmployeesTask
                .Include(e=>e.Employee)
                .Include(e=>e.WorkTask)
                .Include(e=>e.WorkTask.Project)
                .Include(e=>e.WorkTask.TypeOfWorkTask)
                .Where(e=>e.StartWeek.Date<=startWeek.Date && startWeek.Date<=e.StartWeek.AddDays(7)).ToList();
        }

        public IEnumerable<EmployeeTask> GetEmployeeTasks()
        {
            return _companyContext.EmployeesTask.ToList();
        }

        public int GetHoursByWorkTask(WorkTask WorkTask)
        {
            return _companyContext.EmployeesTask.FirstOrDefault(x => x.WorkTask == WorkTask).WorkedHoursOnTask;
        }

        public bool IfExists(EmployeeTask employeeTask)
        {
            return _companyContext.EmployeesTask.Any(x => x.Employee == employeeTask.Employee && x.WorkTask == employeeTask.WorkTask);
        }

        public bool IsEmployeeTaskDone(WorkTask WorkTask)
        {
            var result = _companyContext.EmployeesTask.FirstOrDefault(x => x.WorkTask == WorkTask);

            if(result.Done==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
