using CompanySalaries.DTO;
using CompanySalaries.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompanySalaries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeReportController : ControllerBase
    {
        public IEmployeeRepository employeeRepository;
        public IWorkTaskRepository WorkTaskRepository;
        public IEmployeeTaskRepository employeeTaskRepository;


        public EmployeeReportController(IEmployeeRepository employeeRepository, IWorkTaskRepository WorkTaskRepository, IEmployeeTaskRepository employeeTaskRepository)
        {
            this.employeeRepository = employeeRepository;
            this.WorkTaskRepository = WorkTaskRepository;
            this.employeeTaskRepository = employeeTaskRepository;
        }

        /// <summary>
        /// This method should get a refactor. - by radu
        /// </summary>
        /// <param name="StartWeek"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/GetWeeklyReport")]
        public IEnumerable<EmployeeReportDTO> GetWeeklyReport(DateTime StartWeek)
        {
            var groupedByEmployee = employeeTaskRepository.GetByStartWeek(StartWeek)
                .GroupBy(e => e.Employee)
                .ToDictionary(gdc => gdc.Key, gdc => gdc.ToList());
            var result = new List<EmployeeReportDTO>();

            foreach (var group in groupedByEmployee)
            {
                List<WorkTaskReportDTO> WorkTaskReportDTOList;
                int weeklySalary=0;
                CalculateWorkTaskReportDTOForEmployee(group, out WorkTaskReportDTOList, out weeklySalary);
                var employeeReportDTO = new EmployeeReportDTO()
                {
                    EmployeeName = group.Key.Name,
                    WorkTaskReportDTOs = WorkTaskReportDTOList,
                    WeeklySalary = weeklySalary
                };
                result.Add(employeeReportDTO);
            }
            return result;
        }

        private void CalculateWorkTaskReportDTOForEmployee(KeyValuePair<Models.Employee, List<Models.EmployeeTask>> group, out List<WorkTaskReportDTO> WorkTaskReportDTOList, out int weeklySalary)
        {
            var workedHours = 0;
            var moneyPerWorkTask = 0;
            var projectName = string.Empty;
            var WorkTaskName = string.Empty;
            WorkTaskReportDTOList = new List<WorkTaskReportDTO>();
            weeklySalary = 0;
            foreach (var item in group.Value)
            {
                workedHours = item.WorkedHoursOnTask;

                if (item.WorkTask.TypeOfWorkTask.Name == "special")
                {
                    if (employeeTaskRepository.IsEmployeeTaskDone(item.WorkTask) == true)
                    {
                        moneyPerWorkTask = item.WorkTask.Price;
                    }
                }
                else
                {
                    moneyPerWorkTask = employeeTaskRepository.GetHoursByWorkTask(item.WorkTask) * group.Key.SalaryPerHour;
                }

                weeklySalary += moneyPerWorkTask;
                projectName = item.WorkTask.Project.Name;
                WorkTaskName = item.WorkTask.Name;

                var WorkTaskReportDTO = new WorkTaskReportDTO
                {
                    ProjectName = projectName,
                    WorkTaskName = WorkTaskName,
                    WorkedHours = workedHours,
                    MoneyPerWorkTask = moneyPerWorkTask,
                };
                WorkTaskReportDTOList.Add(WorkTaskReportDTO);
            }
        }
    }
}
