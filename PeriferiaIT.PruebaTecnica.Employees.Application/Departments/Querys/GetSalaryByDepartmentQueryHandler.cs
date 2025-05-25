using MediatR;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;

namespace PeriferiaIT.PruebaTecnica.Employees.Application.Departments.Querys
{
    public record GetSalaryByDepartmentQuery() : IRequest<decimal>
    {
        public required int Id { get; set; }
    }

    class GetSalaryByDepartmentQueryHandler(IEmployeeRepository employeeRepository) : IRequestHandler<GetSalaryByDepartmentQuery, decimal>
    {
        public async Task<decimal> Handle(GetSalaryByDepartmentQuery request, CancellationToken cancellationToken)
        {
            var employees = await employeeRepository.GetEmployeesByDepartment(request.Id, cancellationToken);
            var totalSalary = employees.Sum(x=> x.Salary);
            return totalSalary;
        }
    }
}
