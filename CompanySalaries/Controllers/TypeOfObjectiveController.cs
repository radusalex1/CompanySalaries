using CompanySalaries.Models;
using CompanySalaries.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompanySalaries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfObjectiveController:ControllerBase
    {
        public ITypeOfObjectiveRepository typeOfObjectiveRepository;

        public TypeOfObjectiveController(ITypeOfObjectiveRepository typeOfObjectiveRepository)
        {
            this.typeOfObjectiveRepository = typeOfObjectiveRepository;
        }

        [HttpGet]
        [Route("/GetAllTypes")]
        public IEnumerable<TypeOfObjective> GetAllTypes()
        {
            return typeOfObjectiveRepository.GetAllTypes();
        }

        [HttpPost]
        [Route("/AddTypeOfObjective")]
        public void AddType(TypeOfObjective typeOfObjective)
        {
            typeOfObjectiveRepository.AddType(typeOfObjective);
        }
    }
}
