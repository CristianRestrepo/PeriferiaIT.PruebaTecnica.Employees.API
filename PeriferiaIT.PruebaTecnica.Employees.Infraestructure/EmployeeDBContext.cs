using Microsoft.EntityFrameworkCore;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Entities;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;

namespace PeriferiaIT.PruebaTecnica.Employees.Infraestructure
{
    public class EmployeeDBContext : DbContext, IDbContext
    {
        public EmployeeDBContext(DbContextOptions options) : base(options)
        {                
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
