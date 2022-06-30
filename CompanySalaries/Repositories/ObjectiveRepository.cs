using CompanySalaries.DBContext;
using CompanySalaries.Models;

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
            return _companyContext.Objectives.ToList();
        }
    }
}
