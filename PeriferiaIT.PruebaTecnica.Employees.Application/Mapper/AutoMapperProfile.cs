using AutoMapper;
using PeriferiaIT.PruebaTecnica.Employees.Application.Departments.Commands;
using PeriferiaIT.PruebaTecnica.Employees.Application.Employees.Commands;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Dto;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Entities;

namespace PeriferiaIT.PruebaTecnica.Employees.Application.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
            CreateMap<Department, CreateDepartmentCommand>().ReverseMap();
            CreateMap<EmployeeDto, CreateEmployeeCommand>().ReverseMap();
            CreateMap<DepartmentDto, CreateDepartmentCommand>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();

        }   
    }
}
