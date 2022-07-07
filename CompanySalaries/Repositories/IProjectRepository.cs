using CompanySalaries.Models;

namespace CompanySalaries.Repositories
{
    public interface IProjectRepository
    {
        public void AddProject(Project project);
        public IEnumerable<Project> GetAllProjects();
        public Project GetProjectByName(string name);
        public Project GetProjectById(int id);
        public bool IfExists(Project project);
    }
}
