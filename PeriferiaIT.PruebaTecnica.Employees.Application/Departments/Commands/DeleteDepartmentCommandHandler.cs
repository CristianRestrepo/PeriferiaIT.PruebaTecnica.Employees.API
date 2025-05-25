using MediatR;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;

namespace PeriferiaIT.PruebaTecnica.Employees.Application.Departments.Commands
{
    public record DeleteDepartmentCommand(): IRequest<bool>
    {
        public required int Id { get; set; }
    }

    class DeleteDepartmentCommandHandler(IDepartmentRepository repository) : IRequestHandler<DeleteDepartmentCommand, bool>
    {
        public async Task<bool> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await repository.DeleteDepartment(request.Id, cancellationToken);
        }
    }
}
