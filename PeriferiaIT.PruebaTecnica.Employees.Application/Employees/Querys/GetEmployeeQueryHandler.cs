using AutoMapper;
using MediatR;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Dto;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriferiaIT.PruebaTecnica.Employees.Application.Employees.Querys
{
    public record GetEmployeeQuery() : IRequest<EmployeeDto> 
    {
        public required int Id { get; set; }
    }
    class GetEmployeeQueryHandler(IEmployeeRepository repository, IMapper mapper) : IRequestHandler<GetEmployeeQuery, EmployeeDto>
    {
        public async Task<EmployeeDto> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employee = await repository.GetEmployee(request.Id);
            return mapper.Map<EmployeeDto>(employee);
        }
    }
}
