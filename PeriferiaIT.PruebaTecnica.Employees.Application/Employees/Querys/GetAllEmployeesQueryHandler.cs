using AutoMapper;
using MediatR;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Dto;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;

namespace PeriferiaIT.PruebaTecnica.Employees.Application.Employees.Querys
{
    public record GetAllEmployeesQuery() : IRequest<IEnumerable<EmployeeDto>>;

    public class GetAllEmployeesQueryHandler(IEmployeeRepository repository, IMapper mapper) : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDto>>
    {
        public async Task<IEnumerable<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await repository.GetEmployees(cancellationToken);
            return mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }
    }
}
