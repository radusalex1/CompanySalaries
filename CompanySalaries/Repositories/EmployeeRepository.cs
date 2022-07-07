using CompanySalaries.DBContext;
using CompanySalaries.Models;

namespace CompanySalaries.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {

        public EmployeeRepository(CompanyContext context) : base(context)
        {

        }

        public void AddEmployee(Employee employee)
        {
            _companyContext.Employees.Add(employee);
            _companyContext.SaveChanges();
        }

        public bool IfExists(Employee employee)
        {
            return _companyContext.Employees.Any(e=>e.PhoneNumber==employee.PhoneNumber);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _companyContext.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _companyContext.Employees.FirstOrDefault(x => x.Id == id);
        }

        public Employee GetEmployeeByName(string name)
        {
            return _companyContext.Employees.FirstOrDefault(x => x.Name == name);
        }
    }
}
