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
                .Include(e=>e.Objective)
                .Include(e=>e.Objective.Project)
                .Include(e=>e.Objective.TypeOfObjective)
                .Where(e=>e.StartWeek.Date<=startWeek.Date && startWeek.Date<=e.StartWeek.AddDays(7)).ToList();
        }

        public IEnumerable<EmployeeTask> GetEmployeeTasks()
        {
            return _companyContext.EmployeesTask.ToList();
        }
    }
}
