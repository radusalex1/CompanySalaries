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
        public IWorkTaskRepository workTaskRepository;
        public IProjectRepository projectRepository;
        public ITypeOfWorkTaskRepository typeOfWorkTaskRepository;

        public WorkTaskController(IWorkTaskRepository WorkTaskRepository, IProjectRepository projectRepository, ITypeOfWorkTaskRepository typeOfWorkTaskRepository)
        {
            this.workTaskRepository = WorkTaskRepository;
            this.projectRepository = projectRepository;
            this.typeOfWorkTaskRepository = typeOfWorkTaskRepository;
        }

        [HttpGet]
        [Route("/GetAllWorkTasks")]
        public IEnumerable<WorkTask> GetAllWorkTasks()
        {
            return workTaskRepository.GetAllWorkTasks();
        }

        [HttpPost]
        [Route("/AddWorkTask")]
        public async Task<IActionResult> AddWorkTask(WorkTaskDTO WorkTask)
        {
            var baseProject = projectRepository.GetProjectById(WorkTask.BaseProjectId);
            var typeofWorkTask = typeOfWorkTaskRepository.GetByName(WorkTask.TypeOfWorkTask);

            if(baseProject == null || typeofWorkTask == null)
            {
                return BadRequest("Invalid WorkTask");
            }
            
            var newWorkTask = new WorkTask
            {
                Name = WorkTask.Name,
                Description = WorkTask.Description,
                TypeOfWorkTask = typeofWorkTask,
                Price = WorkTask.Price,
                Project = baseProject,
            };

            if (workTaskRepository.IfExists(newWorkTask))
            {
                return BadRequest("Task Already exists");
            }

            if (WorkTaskValidations.ValidateWorkTask(newWorkTask))
            {
                    workTaskRepository.AddWorkTask(newWorkTask);
            }
            else
            {
                return BadRequest("Invalid WorkTask");
            }

            return Ok("Object Created Successfully");
        }

    }
}
