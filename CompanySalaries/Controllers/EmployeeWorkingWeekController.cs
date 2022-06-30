using CompanySalaries.Models;
using CompanySalaries.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace CompanySalaries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeWorkingWeekController:ControllerBase
    {
        public IEmployeeWorkingWeekRepository employeeWorkingWeekRepository;

        public EmployeeWorkingWeekController(IEmployeeWorkingWeekRepository employeeWorkingWeekRepository)
        {
            this.employeeWorkingWeekRepository = employeeWorkingWeekRepository;
        }  

    }
}
