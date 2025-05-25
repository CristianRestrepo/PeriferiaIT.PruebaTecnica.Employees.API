using AutoMapper;
using MediatR;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Dto;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriferiaIT.PruebaTecnica.Employees.Application.Departments.Querys
{
    public record GetDepartmentQuery() : IRequest<DepartmentDto>
    {
        public required int Id { get; set; }
    }


    class GetDepartmentQueryHandler(IDepartmentRepository repository, IMapper mapper) : IRequestHandler<GetDepartmentQuery, DepartmentDto>
    {
        public async Task<DepartmentDto> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
        {
            var department = await repository.GetDepartment(request.Id, cancellationToken);
            return mapper.Map<DepartmentDto>(department);
        }
    }
}
