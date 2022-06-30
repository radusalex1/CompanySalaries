using CompanySalaries.Models;
using CompanySalaries.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompanySalaries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectiveController : ControllerBase
    {
        public IObjectiveRepository objectiveRepository;

        public ObjectiveController(IObjectiveRepository objectiveRepository)
        {
            this.objectiveRepository = objectiveRepository;
        }

        [HttpGet]
        [Route("/GetAllObjectives")]
        public IEnumerable<Objective> GetAllObjectives()
        {
            return objectiveRepository.GetAllObjectives();
        }

        [HttpPost]
        [Route("/AddObjective")]
        public void AddObjective(Objective objective)
        {
            objectiveRepository.AddObjective(objective);
        }

    }
}
