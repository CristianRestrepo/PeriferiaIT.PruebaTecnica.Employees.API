using AutoMapper;
using MediatR;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Dto;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Entities;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;

namespace PeriferiaIT.PruebaTecnica.Employees.Application.Departments.Commands
{
    public record CreateDepartmentCommand() : IRequest<DepartmentDto>
    {
        public required string Name { get; set; }
    };

    class CreateDepartmentCommandHandler(IDepartmentRepository repository, IMapper mapper) : IRequestHandler<CreateDepartmentCommand, DepartmentDto>
    {
        public async Task<DepartmentDto> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            Department newDepartment = mapper.Map<Department>(request);
            await repository.AddDepartment(newDepartment);
            return mapper.Map<DepartmentDto>(newDepartment);
        }
    }
}
