using CompanySalaries.DBContext;
using CompanySalaries.Models;

namespace CompanySalaries.Repositories
{
    public class TypeOfWorkTaskRepository : BaseRepository, ITypeOfWorkTaskRepository
    {
        public TypeOfWorkTaskRepository(CompanyContext companyContext) : base(companyContext)
        {

        }

        public void AddType(TypeOfWorkTask typeOfWorkTask)
        {
            _companyContext.TypeOfWorkTasks.Add(typeOfWorkTask);
            _companyContext.SaveChanges();
        }

        public IEnumerable<TypeOfWorkTask> GetAllTypes()
        {
            return _companyContext.TypeOfWorkTasks.ToList();
        }

        public TypeOfWorkTask GetByName(string name)
        {
            return _companyContext.TypeOfWorkTasks.FirstOrDefault(t=>t.Name== name);
        }
    }
}
