using CompanySalaries.Models;
using CompanySalaries.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompanySalaries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        public IProjectRepository projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        [HttpGet]
        [Route("/GetAllProjects")]
        public IEnumerable<Project> GetAllProjects()
        {
            return projectRepository.GetAllProjects();
        }

        [HttpPost]
        [Route("/AddProject")]
        public void AddProject(Project project)
        {
            projectRepository.AddProject(project);
        }

    }
}
