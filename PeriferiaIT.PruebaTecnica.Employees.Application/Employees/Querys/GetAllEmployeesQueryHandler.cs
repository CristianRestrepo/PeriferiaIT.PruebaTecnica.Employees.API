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
    public record GetAllEmployeesQuery() : IRequest<IEnumerable<EmployeeDto>>;

    class GetAllEmployeesQueryHandler(IEmployeeRepository repository, IMapper mapper) : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDto>>
    {
        public async Task<IEnumerable<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await repository.GetEmployees();
            return mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }
    }
}
