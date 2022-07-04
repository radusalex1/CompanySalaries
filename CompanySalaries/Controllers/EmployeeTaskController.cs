using CompanySalaries.DTO;
using CompanySalaries.Models;
using CompanySalaries.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompanySalaries.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTaskController : ControllerBase
    {

        public IEmployeeTaskRepository employeeTaskRepository;
        public IEmployeeRepository employeeRepository;
        public IWorkTaskRepository WorkTaskRepository;

        public EmployeeTaskController(IEmployeeTaskRepository employeeTaskRepository,IEmployeeRepository employeeRepository,IWorkTaskRepository WorkTaskRepository)
        {
            this.employeeTaskRepository = employeeTaskRepository;
            this.employeeRepository = employeeRepository;
            this.WorkTaskRepository = WorkTaskRepository;
        }

        [HttpGet]
        [Route("/GetEmployeeTask")]
        public IEnumerable<EmployeeTask> GetEmployeeTask()
        {
           return employeeTaskRepository.GetEmployeeTasks();
        }

        [HttpPost]
        [Route("/AddEmployeeTask")]
        public async Task<IActionResult> AddEmployeeTask(EmployeeTaskDTO employeeTaskDTO)
        {
            var employee = employeeRepository.GetEmployeeById(employeeTaskDTO.EmployeeId);
            var worktask = WorkTaskRepository.GetWorkTaskById(employeeTaskDTO.WorkTaskId);

            if(employee == null || worktask==null)
            {
                return BadRequest("Invalid employee or worktask");
            }

            var employeeTask = new EmployeeTask
            {
                Employee = employee,
                WorkTask = worktask,  
                StartWeek = employeeTaskDTO.StartWeek,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                WorkedHoursOnTask= employeeTaskDTO.WorkedHoursOnTask,
                Done = employeeTaskDTO.Done
            };
            employeeTaskRepository.AddEmployeeTask(employeeTask);
            return Ok("Data inserted successfully");
        }
    }
}
