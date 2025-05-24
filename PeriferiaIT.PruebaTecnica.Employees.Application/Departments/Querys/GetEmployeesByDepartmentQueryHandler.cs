using AutoMapper;
using MediatR;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Dto;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Entities;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriferiaIT.PruebaTecnica.Employees.Application.Departments.Querys
{
    public record GetEmployeesByDepartmentQuery() : IRequest<IEnumerable<EmployeeDto>>
    {
        public required int Id { get; set; }
    }
    

    class GetEmployeesByDepartmentQueryHandler(IDepartmentRepository repository, IEmployeeRepository employeeRepository, IMapper mapper) : IRequestHandler<GetEmployeesByDepartmentQuery, IEnumerable<EmployeeDto>>
    {
        public async Task<IEnumerable<EmployeeDto>> Handle(GetEmployeesByDepartmentQuery request, CancellationToken cancellationToken)
        {
            var employees = await employeeRepository.GetEmployees();
            IEnumerable<Employee> employeesByDepartment = employees.Where(x => x.DepartmentId.Equals(request.Id)).AsEnumerable();
            return mapper.Map<IEnumerable<EmployeeDto>>(employeesByDepartment);
        }
    }
}
