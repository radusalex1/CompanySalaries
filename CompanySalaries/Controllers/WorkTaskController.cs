using CompanySalaries.DTO;
using CompanySalaries.Models;
using CompanySalaries.Repositories;
using CompanySalaries.Validations;
using Microsoft.AspNetCore.Mvc;

namespace CompanySalaries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkTaskController : ControllerBase
    {
        public IWorkTaskRepository WorkTaskRepository;
        public IProjectRepository projectRepository;
        public ITypeOfWorkTaskRepository typeOfWorkTaskRepository;

        public WorkTaskController(IWorkTaskRepository WorkTaskRepository, IProjectRepository projectRepository, ITypeOfWorkTaskRepository typeOfWorkTaskRepository)
        {
            this.WorkTaskRepository = WorkTaskRepository;
            this.projectRepository = projectRepository;
            this.typeOfWorkTaskRepository = typeOfWorkTaskRepository;
        }

        [HttpGet]
        [Route("/GetAllWorkTasks")]
        public IEnumerable<WorkTask> GetAllWorkTasks()
        {
            return WorkTaskRepository.GetAllWorkTasks();
        }

        [HttpPost]
        [Route("/AddWorkTask")]
        public async Task<IActionResult> AddWorkTask(WorkTaskDTO WorkTask)
        {
            var nameBaseProject = projectRepository.GetProjectById(WorkTask.BaseProjectId);
            var typeofWorkTask = typeOfWorkTaskRepository.GetByName(WorkTask.TypeOfWorkTask);

            if(nameBaseProject == null || typeofWorkTask == null)
            {
                return BadRequest("Invalid WorkTask");
            }
            
            var newWorkTask = new WorkTask
            {
                Name = WorkTask.Name,
                Description = WorkTask.Description,
                TypeOfWorkTask = typeofWorkTask,
                Price = WorkTask.Price,
                Project = nameBaseProject,
            };

            if (WorkTaskValidations.ValidateWorkTask(newWorkTask))
            {
                WorkTaskRepository.AddWorkTask(newWorkTask);
            }
            else
            {
                return BadRequest("Invalid WorkTask");
            }

            return Ok("Object Created Successfully");
        }

    }
}
