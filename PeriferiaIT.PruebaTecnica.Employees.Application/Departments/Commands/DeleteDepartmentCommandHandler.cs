using MediatR;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriferiaIT.PruebaTecnica.Employees.Application.Departments.Commands
{
    public record DeleteDepartmentCommand(int id): IRequest<bool>
    {
        public int Id { get; set; } = id;
    }

    class DeleteDepartmentCommandHandler(IDepartmentRepository repository) : IRequestHandler<DeleteDepartmentCommand, bool>
    {
        public async Task<bool> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await repository.DeleteDepartment(request.Id);
        }
    }
}
