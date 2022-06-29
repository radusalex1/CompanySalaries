using CompanySalaries.DBContext;

namespace CompanySalaries.Repositories
{
    public class BaseRepository
    {
        public readonly CompanyContext _companyContext;

        public BaseRepository(CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }
    }
}
