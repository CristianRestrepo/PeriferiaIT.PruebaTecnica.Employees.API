using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Entities;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;

namespace PeriferiaIT.PruebaTecnica.Employees.Infraestructure.Repository
{
    public class DepartmentRepository(IDbContext _context, ILogger<DepartmentRepository> _logger) : IDepartmentRepository
    {
        public async Task AddDepartment(Department department, CancellationToken cancellationToken)
        {
            try
            {
                _context.Departments.Add(department);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError("Error adding department: " + e.Message);
                throw;
            }
        }

        public async Task<bool> DeleteDepartment(int id, CancellationToken cancellationToken)
        {
            try
            {
                var department = await _context.Departments.FindAsync(id, cancellationToken);

                if (department == null)
                {
                    return false;
                }

                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError("Error delete department: " + e.Message);
                throw;
            }
           
        }

        public async Task<Department?> GetDepartment(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Departments.FindAsync(id, cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError("Error get department by id: " + e.Message);
                throw;
            }
                    
        }

        public async Task<IEnumerable<Department>> GetDepartments(CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Departments.ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError("Error get departments: " + e.Message);
                throw;
            }
            
        }

        public async Task UpdateDepartment(Department department, CancellationToken cancellationToken)
        {
            try
            {
                _context.Entry(department).State = EntityState.Modified;
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e )
            {
                _logger.LogError("Error update department: " + e.Message);
                throw;
            }
           
        }
    }
}
