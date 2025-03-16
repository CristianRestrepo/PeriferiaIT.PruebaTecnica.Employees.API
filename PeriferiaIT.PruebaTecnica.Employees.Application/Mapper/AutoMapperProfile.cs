using AutoMapper;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Dto;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Entities;

namespace PeriferiaIT.PruebaTecnica.Employees.Application.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, AddEmployeeDto>().ReverseMap();
            CreateMap<Department, AddDepartmentDto>().ReverseMap();
            CreateMap<EmployeeDto, AddEmployeeDto>().ReverseMap();
            CreateMap<DepartmentDto, AddDepartmentDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();

        }   
    }
}
