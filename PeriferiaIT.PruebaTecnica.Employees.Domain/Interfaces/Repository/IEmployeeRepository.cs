using PeriferiaIT.PruebaTecnica.Employees.Domain.Entities;

namespace PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetEmployees(CancellationToken cancellationToken);

        public Task<Employee?> GetEmployee(int id, CancellationToken cancellationToken);

        public Task<IEnumerable<Employee>> GetEmployeesByDepartment(int id, CancellationToken cancellationToken);

        public Task AddEmployee(Employee employee, CancellationToken cancellationToken);

        public Task UpdateEmployee(Employee employee, CancellationToken cancellationToken);

        public Task<bool> DeleteEmployee(int id, CancellationToken cancellationToken);

    }
}
