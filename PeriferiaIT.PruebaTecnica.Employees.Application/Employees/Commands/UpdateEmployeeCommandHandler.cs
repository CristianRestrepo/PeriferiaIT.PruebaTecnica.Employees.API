using AutoMapper;
using MediatR;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Common;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Entities;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriferiaIT.PruebaTecnica.Employees.Application.Employees.Commands
{
    public record UpdateEmployeeCommand() : IRequest<Unit>
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public decimal Salary { get; set; }
        public JobPosition Position { get; set; }
        public required int DepartmentId { get; set; }
    };

    class UpdateEmployeeCommandHandler(IEmployeeRepository repository, IMapper _mapper) : IRequestHandler<UpdateEmployeeCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            await repository.UpdateEmployee(_mapper.Map<Employee>(request));
            return Unit.Value;
        }
    }
}
