using AutoMapper;
using MediatR;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Common;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Dto;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Entities;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;

namespace PeriferiaIT.PruebaTecnica.Employees.Application.Employees.Commands
{
    public record CreateEmployeeCommand() : IRequest<EmployeeDto>
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public decimal Salary { get; set; }
        public JobPosition Position { get; set; }
        public required int DepartmentId { get; set; }
    };
    public class CreateEmployeeCommandHandler(IEmployeeRepository _repository, IMapper _mapper, ISalaryService salaryService) : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
    {
        public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee newEmployee = _mapper.Map<Employee>(request);
            newEmployee.Salary = salaryService.CalculateSalary(newEmployee.Salary, newEmployee.Position);
            await _repository.AddEmployee(newEmployee, cancellationToken);
            return _mapper.Map<EmployeeDto>(newEmployee);
        }
    }
}
