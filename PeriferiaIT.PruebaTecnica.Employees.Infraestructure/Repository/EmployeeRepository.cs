using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Entities;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;

namespace PeriferiaIT.PruebaTecnica.Employees.Infraestructure.Repository
{
    public class EmployeeRepository(IDbContext _context, ILogger<EmployeeRepository> _logger) : IEmployeeRepository
    {
        public async Task AddEmployee(Employee employee, CancellationToken cancellationToken)
        {
            try
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError("Error adding employee: " + e.Message);
                throw;
            }

        }

        public async Task<bool> DeleteEmployee(int id, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(id);
                if (employee == null)
                {
                    return false;
                }

                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError("Error delete employee: " + e.Message);
                throw;
            }

        }

        public async Task<Employee?> GetEmployee(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Employees.FindAsync(id, cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError("Error get employee by id: " + e.Message);
                throw;
            }

        }

        public async Task<IEnumerable<Employee>> GetEmployees(CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Employees.ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {

                _logger.LogError("Error get employees: " + e.Message);
                throw;
            }

        }

        public async Task<IEnumerable<Employee>> GetEmployeesByDepartment(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Employees.Where(x => x.DepartmentId == id).ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {

                _logger.LogError("Error get employees: " + e.Message);
                throw;
            }
        }

        public async Task UpdateEmployee(Employee employee, CancellationToken cancellationToken)
        {
            try
            {
                _context.Entry(employee).State = EntityState.Modified;
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError("Error update employee: " + e.Message);
                throw;
            }
        }
    }
}
