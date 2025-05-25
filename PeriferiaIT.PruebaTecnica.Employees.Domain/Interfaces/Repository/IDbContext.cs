using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Entities;

namespace PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository
{
    public interface IDbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        EntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
