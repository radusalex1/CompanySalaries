using CompanySalaries.Models;

namespace CompanySalaries.Repositories
{
    public interface ITypeOfWorkTaskRepository
    {
        public void AddType(TypeOfWorkTask typeOfWorkTask);
        public IEnumerable<TypeOfWorkTask> GetAllTypes();
        public TypeOfWorkTask GetByName(string name);
    }
}
