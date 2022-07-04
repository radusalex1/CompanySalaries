using CompanySalaries.Models;
using CompanySalaries.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompanySalaries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfWorkTaskController:ControllerBase
    {
        public ITypeOfWorkTaskRepository typeOfWorkTaskRepository;

        public TypeOfWorkTaskController(ITypeOfWorkTaskRepository typeOfWorkTaskRepository)
        {
            this.typeOfWorkTaskRepository = typeOfWorkTaskRepository;
        }

        [HttpGet]
        [Route("/GetAllTypes")]
        public IEnumerable<TypeOfWorkTask> GetAllTypes()
        {
            return typeOfWorkTaskRepository.GetAllTypes();
        }

        [HttpPost]
        [Route("/AddTypeOfWorkTask")]
        public void AddType(TypeOfWorkTask typeOfWorkTask)
        {
            typeOfWorkTaskRepository.AddType(typeOfWorkTask);
        }
    }
}
