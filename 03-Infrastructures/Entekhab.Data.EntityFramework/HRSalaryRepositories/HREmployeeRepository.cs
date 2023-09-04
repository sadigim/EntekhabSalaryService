using Entekhab.Data.EntityFramework.DbContexts;
using Entekhab.Data.EntityFramework.Infrastructures.Repositories;
using Entekhab.Domain.Entities.HumanResourceModels;


namespace Entekhab.Data.EntityFramework.HRSalaryRepositories;

public class HREmployeeRepository : DalRepository<HREmployeeModel>
{
    public HREmployeeRepository(MainDbContext dbContext) : base(dbContext)
    {
    }
}