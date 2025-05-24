using MediatR;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriferiaIT.PruebaTecnica.Employees.Application.Employees.Commands
{
    public record DeleteEmployeeCommand() : IRequest<bool>
    {
        public required int Id { get; set; }
    };
    class DeleteEmployeeCommandHandler(IEmployeeRepository repository) : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await repository.DeleteEmployee(request.Id);
        }
    }
}
