using CompanySalaries.Models;

namespace CompanySalaries.Repositories
{
    public interface IEmployeeTaskRepository
    {
        public void AddEmployeeTask(EmployeeTask employeeTask);
        public IEnumerable<EmployeeTask> GetEmployeeTasks();
        public IEnumerable<EmployeeTask> GetByStartWeek(DateTime startWeek);
        public bool IsEmployeeTaskDone(Objective objective);
        public int GetHoursByObjective(Objective objective);
    }
}
