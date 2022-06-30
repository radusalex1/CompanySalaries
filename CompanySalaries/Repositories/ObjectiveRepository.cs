using CompanySalaries.DBContext;
using CompanySalaries.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanySalaries.Repositories
{
    public class ObjectiveRepository : BaseRepository, IObjectiveRepository
    {

        public ObjectiveRepository(CompanyContext context) : base(context)
        {

        }

        public void AddObjective(Objective objective)
        {
            _companyContext.Objectives.Add(objective);
            _companyContext.SaveChanges();
        }

        public IEnumerable<Objective> GetAllObjectives()
        {
            return _companyContext.Objectives
                .Include(o=>o.TypeOfObjective)
                .Include(o=>o.Project)
                .ToList();
        }

        public Objective GetObjectiveByName(string name)
        {
            return _companyContext.Objectives
                .Include(o=>o.TypeOfObjective)
                .Include(o => o.Project)
                .Where(o=>o.Name==name).FirstOrDefault();
        }
    }
}
