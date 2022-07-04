using CompanySalaries.Models;
using CompanySalaries.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompanySalaries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController:ControllerBase
    {
        public IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        [Route("/GetAllEmployees")]
        public IEnumerable<Employee> GetAllEmployees()
        {
            return employeeRepository.GetAllEmployees();
        }

        [HttpPost]
        [Route("/AddEmployee")]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            if (!employeeRepository.Exists(employee))
            {
                employeeRepository.AddEmployee(employee);
            }
            else
            {
                return BadRequest("Employee already exists");
            }
            return Ok("Employee added successfully");
        }

    }
}
