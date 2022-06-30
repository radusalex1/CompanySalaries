using CompanySalaries.Models;

namespace CompanySalaries.Repositories
{
    public interface IEmployeeWorkingWeekRepository
    {
        public void AddEmployeeWorkingWeek(EmployeeWorkingWeek employeeWorkingWeek);
        public IEnumerable<EmployeeWorkingWeek> GetAllEmployeesWorkingWeek();
    }
}
