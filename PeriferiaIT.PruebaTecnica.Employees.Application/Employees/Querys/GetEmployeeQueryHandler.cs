using AutoMapper;
using MediatR;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Dto;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;

namespace PeriferiaIT.PruebaTecnica.Employees.Application.Employees.Querys
{
    public record GetEmployeeQuery() : IRequest<EmployeeDto> 
    {
        public required int Id { get; set; }
    }
    public class GetEmployeeQueryHandler(IEmployeeRepository repository, IMapper mapper) : IRequestHandler<GetEmployeeQuery, EmployeeDto>
    {
        public async Task<EmployeeDto> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employee = await repository.GetEmployee(request.Id, cancellationToken);
            return mapper.Map<EmployeeDto>(employee);
        }
    }
}
