using CompanySalaries.DBContext;
using CompanySalaries.Models;

namespace CompanySalaries.Repositories
{
    public class TypeOfObjectiveRepository : BaseRepository, ITypeOfObjectiveRepository
    {
        public TypeOfObjectiveRepository(CompanyContext companyContext) : base(companyContext)
        {

        }

        public void AddType(TypeOfObjective typeOfObjective)
        {
            _companyContext.TypeOfObjectives.Add(typeOfObjective);
            _companyContext.SaveChanges();
        }

        public IEnumerable<TypeOfObjective> GetAllTypes()
        {
            return _companyContext.TypeOfObjectives.ToList();
        }

        public TypeOfObjective GetByName(string name)
        {
            return _companyContext.TypeOfObjectives.FirstOrDefault(t=>t.Name== name);
        }
    }
}
