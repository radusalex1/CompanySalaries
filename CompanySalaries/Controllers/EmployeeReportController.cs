using CompanySalaries.DTO;
using CompanySalaries.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CompanySalaries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeReportController : ControllerBase
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
            var grouped = EmployeesTaskLastWeek.GroupBy(e => e.Employee).ToDictionary(gdc => gdc.Key, gdc => gdc.ToList());
            var result = new List<EmployeeReportDTO>();

            foreach (var group in grouped)
            {
                var workedHours = 0;
                var moneyPerObjective = 0;
                var projectName = string.Empty;
                var objectiveName = string.Empty;
                var objectiveReportDTOList = new List<ObjectiveReportDTO>();
                var weeklySalary = 0;

                foreach (var item in group.Value)
                {
                    workedHours = item.WorkedHoursOnTask;

                    if (item.Objective.TypeOfObjective.Name == "special")
                    {
                        if (employeeTaskRepository.IsEmployeeTaskDone(item.Objective) == true)
                        {
                            moneyPerObjective = item.Objective.Price;
                        }
                    }
                    else
                    {
                        moneyPerObjective = employeeTaskRepository.GetHoursByObjective(item.Objective) * group.Key.SalaryPerHour;
                    }

                    weeklySalary += moneyPerObjective;
                    projectName = item.Objective.Project.Name;
                    objectiveName = item.Objective.Name;

                    var objectiveReportDTO = new ObjectiveReportDTO
                    {
                        ProjectName = projectName,
                        ObjectiveName = objectiveName,
                        WorkedHours = workedHours,
                        MoneyPerObjective = moneyPerObjective,
                    };
                    objectiveReportDTOList.Add(objectiveReportDTO); 

                }
                var employeeReportDTO = new EmployeeReportDTO()
                {
                    EmployeeName = group.Key.Name,
                    objectiveReportDTOs = objectiveReportDTOList,
                    WeeklySalary = weeklySalary
                };

                result.Add(employeeReportDTO);

            }
            
            return result;

        }
    }
}
