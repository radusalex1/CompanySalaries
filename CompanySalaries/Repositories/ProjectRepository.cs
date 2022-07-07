using CompanySalaries.DBContext;
using CompanySalaries.Models;

namespace CompanySalaries.Repositories
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {

        public ProjectRepository(CompanyContext context) : base(context)
        {

        }

        public void AddProject(Project project)
        {
            _companyContext.Projects.Add(project);
            _companyContext.SaveChanges();
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return _companyContext.Projects.ToList();
        }

        public Project GetProjectById(int id)
        {
            return _companyContext.Projects.FirstOrDefault(p => p.Id == id);
        }

        public Project GetProjectByName(string name)
        {
            return _companyContext.Projects.FirstOrDefault(p => p.Name == name);

        }

        public bool IfExists(Project project)
        {
            return _companyContext.Projects.Any(p => p.Name == project.Name);
        }
    }
}
