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
        public IObjectiveRepository objectiveRepository;

        public EmployeeTaskController(IEmployeeTaskRepository employeeTaskRepository,IEmployeeRepository employeeRepository,IObjectiveRepository objectiveRepository)
        {
            this.employeeTaskRepository = employeeTaskRepository;
            this.employeeRepository = employeeRepository;
            this.objectiveRepository = objectiveRepository;
        }

        [HttpGet]
        [Route("/GetEmployeeTask")]
        public IEnumerable<EmployeeTask> GetEmployeeTask()
        {
           return employeeTaskRepository.GetEmployeeTasks();
        }

        [HttpPost]
        [Route("/AddEmployeeTask")]
        public void AddEmployeeTask(EmployeeTaskDTO employeeTaskDTO)
        {
            var employeeTask = new EmployeeTask
            {
                Employee = employeeRepository.GetEmployeeByName(employeeTaskDTO.EmployeeName),
                Objective = objectiveRepository.GetObjectiveByName(employeeTaskDTO.ObjectiveName),  
                StartWeek = employeeTaskDTO.StartWeek,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                WorkedHoursOnTask= employeeTaskDTO.WorkedHoursOnTask,
                Done = employeeTaskDTO.Done
            };
            employeeTaskRepository.AddEmployeeTask(employeeTask);
        }
    }
}
