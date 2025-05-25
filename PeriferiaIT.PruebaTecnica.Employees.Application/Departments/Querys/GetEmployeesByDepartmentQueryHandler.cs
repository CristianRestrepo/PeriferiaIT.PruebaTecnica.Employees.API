using AutoMapper;
using MediatR;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Dto;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;

namespace PeriferiaIT.PruebaTecnica.Employees.Application.Departments.Querys
{
    public record GetEmployeesByDepartmentQuery() : IRequest<IEnumerable<EmployeeDto>>
    {
        public required int Id { get; set; }
    }
    

    class GetEmployeesByDepartmentQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper) : IRequestHandler<GetEmployeesByDepartmentQuery, IEnumerable<EmployeeDto>>
    {
        public async Task<IEnumerable<EmployeeDto>> Handle(GetEmployeesByDepartmentQuery request, CancellationToken cancellationToken)
        {
            var employeesByDepartment = await employeeRepository.GetEmployeesByDepartment(request.Id, cancellationToken);            
            return mapper.Map<IEnumerable<EmployeeDto>>(employeesByDepartment);
        }
    }
}
