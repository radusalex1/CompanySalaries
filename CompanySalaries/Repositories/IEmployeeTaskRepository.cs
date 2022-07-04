using CompanySalaries.Models;

namespace CompanySalaries.Repositories
{
    public interface IEmployeeTaskRepository
    {
        public void AddEmployeeTask(EmployeeTask employeeTask);
        public IEnumerable<EmployeeTask> GetEmployeeTasks();
        public IEnumerable<EmployeeTask> GetByStartWeek(DateTime startWeek);
        public bool IsEmployeeTaskDone(WorkTask WorkTask);
        public int GetHoursByWorkTask(WorkTask WorkTask);
    }
}
