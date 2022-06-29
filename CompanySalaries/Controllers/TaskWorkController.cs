using CompanySalaries.Models;
using CompanySalaries.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompanySalaries.Controllers
{ 
    [ApiController]
    public class TaskWorkController:ControllerBase
    {
        public ITaskWorkRepository taskWorkRepository;
        public TaskWorkController(ITaskWorkRepository taskWorkRepository)
        {
            this.taskWorkRepository = taskWorkRepository;
        }

        [HttpGet]
        [Route("/GetAllTasks")]
        public IEnumerable<TaskWork> GetAllTasks()
        {
            return taskWorkRepository.GetAllTasks();
        }

        [HttpPost]
        [Route("/AddTask")]
        public void AddTask(TaskWork taskWork)
        {
            taskWorkRepository.AddTask(taskWork);
        }
    }
}
