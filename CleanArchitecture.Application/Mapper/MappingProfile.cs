using AutoMapper;
using CleanArchitecture.Application.DTO;
using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ForMember(
                a => a.Id,
                b => b.MapFrom(c => c.EmployeeId)).ReverseMap();
        }
    }
}