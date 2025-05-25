using PeriferiaIT.PruebaTecnica.Employees.Domain.Entities;

namespace PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments(CancellationToken cancellationToken);

        Task<Department?> GetDepartment(int id, CancellationToken cancellationToken);

        Task AddDepartment(Department department, CancellationToken cancellationToken);

        Task UpdateDepartment(Department department, CancellationToken cancellationToken);

        Task<bool> DeleteDepartment(int id, CancellationToken cancellationToken);
    }
}
