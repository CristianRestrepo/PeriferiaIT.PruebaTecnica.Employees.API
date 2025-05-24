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
    public record GetAllDepartmentQuery() : IRequest<List<DepartmentDto>>
    {       
    }

    public class GetAllDepartmentQueryHandler(IDepartmentRepository repository, IMapper mapper) : IRequestHandler<GetAllDepartmentQuery, List<DepartmentDto>>
    {
        public async Task<List<DepartmentDto>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            var departments = await repository.GetDepartments();
            return mapper.Map<List<DepartmentDto>>(departments);
        }
    }
}
