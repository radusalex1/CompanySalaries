using CompanySalaries.DBContext;
using CompanySalaries.Models;

namespace CompanySalaries.Repositories
{
    public class EmployeeWorkingWeekRepository : BaseRepository, IEmployeeWorkingWeekRepository
    {

        public EmployeeWorkingWeekRepository(CompanyContext context) : base(context)
        {

        }

        public void AddEmployeeWorkingWeek(EmployeeWorkingWeek employeeWorkingWeek)
        {
            _companyContext.EmployeesWorkingWeek.Add(employeeWorkingWeek);
            _companyContext.SaveChanges();
        }

        public IEnumerable<EmployeeWorkingWeek> GetAllEmployeesWorkingWeek()
        {
            return _companyContext.EmployeesWorkingWeek.ToList();
        }
    }
}
