using CleanArchitecture.Core.Entities;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Repositories.Base;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee>
    {
        public EmployeeRepository(ApiContext context) : base(context)
        {
        }
    }
}