﻿using CompanySalaries.DBContext;
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
    }
}