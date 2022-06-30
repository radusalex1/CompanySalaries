using CompanySalaries.DTO;
using CompanySalaries.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompanySalaries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeReportController:ControllerBase
    {
        public IEmployeeRepository employeeRepository;
        public IObjectiveRepository objectiveRepository;
        public IEmployeeTaskRepository employeeTaskRepository;

        public EmployeeReportController(IEmployeeRepository employeeRepository, IObjectiveRepository objectiveRepository, IEmployeeTaskRepository employeeTaskRepository)
        {
            this.employeeRepository = employeeRepository;
            this.objectiveRepository = objectiveRepository;
            this.employeeTaskRepository = employeeTaskRepository;
        }

        [HttpGet]
        [Route("/GetWeeklyReport")]
        public IEnumerable<EmployeeReportDTO> GetWeeklyReport(DateTime StartWeek)
        {
            var EmployeesTaskLastWeek = employeeTaskRepository.GetByStartWeek(StartWeek);
            var grouped = EmployeesTaskLastWeek.GroupBy(e => e.Employee.Name);

            foreach(var group in grouped)
            {
                
            }
            var result = new List<EmployeeReportDTO>();
            return result;
           
        }
    }
}
