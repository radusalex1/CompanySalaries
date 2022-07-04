using CompanySalaries.Models;

namespace CompanySalaries.Repositories
{
    public interface IEmployeeRepository
    {
        public void AddEmployee(Employee employee);
        public IEnumerable<Employee> GetAllEmployees();
        public Employee GetEmployeeByName(string name);
        public Employee GetEmployeeById(int id);
        public bool Exists(Employee employee);
    }
}
