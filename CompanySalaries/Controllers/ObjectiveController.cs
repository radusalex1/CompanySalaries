using CompanySalaries.DTO;
using CompanySalaries.Models;
using CompanySalaries.Repositories;
using CompanySalaries.Validations;
using Microsoft.AspNetCore.Mvc;

namespace CompanySalaries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectiveController : ControllerBase
    {
        public IObjectiveRepository objectiveRepository;
        public IProjectRepository projectRepository;
        public ITypeOfObjectiveRepository typeOfObjectiveRepository;

        public ObjectiveController(IObjectiveRepository objectiveRepository, IProjectRepository projectRepository, ITypeOfObjectiveRepository typeOfObjectiveRepository)
        {
            this.objectiveRepository = objectiveRepository;
            this.projectRepository = projectRepository;
            this.typeOfObjectiveRepository = typeOfObjectiveRepository;
        }

        [HttpGet]
        [Route("/GetAllObjectives")]
        public IEnumerable<Objective> GetAllObjectives()
        {
            return objectiveRepository.GetAllObjectives();
        }

        [HttpPost]
        [Route("/AddObjective")]
        public async Task<IActionResult> AddObjective(ObjectiveDTO objective)
        {
            var nameBaseProject = projectRepository.GetProjectByName(objective.NameBaseProject);
            var typeofObjective = typeOfObjectiveRepository.GetByName(objective.TypeOfObjective);

            if(nameBaseProject == null || typeofObjective == null)
            {
                return BadRequest("Invalid Objective");
            }
            
            var newObjective = new Objective
            {
                Name = objective.Name,
                Description = objective.Description,
                TypeOfObjective = typeofObjective,
                Price = objective.Price,
                Project = nameBaseProject,
            };

            if (ObjectiveValidations.ValidateObjective(newObjective))
            {
                objectiveRepository.AddObjective(newObjective);
            }
            else
            {
                return BadRequest("Invalid Objective");
            }

            return Ok("Object Created Successfully");
        }

    }
}
