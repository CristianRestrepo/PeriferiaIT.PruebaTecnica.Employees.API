using MediatR;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;

namespace PeriferiaIT.PruebaTecnica.Employees.Application.Employees.Commands
{
    public record DeleteEmployeeCommand() : IRequest<bool>
    {
        public required int Id { get; set; }
    };
    public class DeleteEmployeeCommandHandler(IEmployeeRepository repository) : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await repository.DeleteEmployee(request.Id, cancellationToken);
        }
    }
}
