using CompanySalaries.Models;

namespace CompanySalaries.Repositories
{
    public interface IObjectiveRepository
    {
        public void AddObjective(Objective objective);
        public IEnumerable<Objective> GetAllObjectives();
    }
}
