using AutoMapper;
using CleanArchitecture.Application.DTO;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Repositories.Base;

namespace CleanArchitecture.Application.Manager
{
    public class EmployeeManager : BaseManager<EmployeeDto, Employee>
    {
        public EmployeeManager(IRepository<Employee> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}