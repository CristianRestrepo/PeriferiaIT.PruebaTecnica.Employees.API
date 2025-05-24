using AutoMapper;
using MediatR;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Entities;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriferiaIT.PruebaTecnica.Employees.Application.Departments.Commands
{
    public record UpdateDepartmentCommand() : IRequest<Unit>
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
    };

    class UpdateDepartmentCommandHandler(IDepartmentRepository repository, IMapper mapper) : IRequestHandler<UpdateDepartmentCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            await repository.UpdateDepartment(mapper.Map<Department>(request));
            return Unit.Value;
        }
    }
}
