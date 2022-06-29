using CompanySalaries.DBContext;
using CompanySalaries.Models;

namespace CompanySalaries.Repositories
{
    public class EmployeeRepository : BaseRepository,IEmployeeRepository
    {
       
        public EmployeeRepository(CompanyContext context):base(context)
        {
           
        }

        public void AddEmployee(Employee employee)
        {
            _companyContext.Employees.Add(employee);
            _companyContext.SaveChanges();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _companyContext.Employees.ToList();
        }
    }
}
