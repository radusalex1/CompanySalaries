using CompanySalaries.Models;

namespace CompanySalaries.Repositories
{
    public interface ITypeOfObjectiveRepository
    {
        public void AddType(TypeOfObjective typeOfObjective);
        public IEnumerable<TypeOfObjective> GetAllTypes();
        public TypeOfObjective GetByName(string name);
    }
}
