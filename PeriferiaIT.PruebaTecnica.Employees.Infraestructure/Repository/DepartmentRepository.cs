using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Entities;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;

namespace PeriferiaIT.PruebaTecnica.Employees.Infraestructure.Repository
{
    public class DepartmentRepository(EmployeeDBContext _context, ILogger<DepartmentRepository> _logger) : IDepartmentRepository
    {
        public async Task AddDepartment(Department department)
        {
            try
            {
                _context.Departments.Add(department);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError("Error adding department: " + e.Message);
                throw;
            }
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            try
            {
                var department = await _context.Departments.FindAsync(id);

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

        public async Task<Department?> GetDepartment(int id)
        {
            try
            {
                return await _context.Departments.FindAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError("Error get department by id: " + e.Message);
                throw;
            }
                    
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            try
            {
                return await _context.Departments.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError("Error get departments: " + e.Message);
                throw;
            }
            
        }

        public async Task UpdateDepartment(Department department)
        {
            try
            {
                _context.Entry(department).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception e )
            {
                _logger.LogError("Error update department: " + e.Message);
                throw;
            }
           
        }
    }
}
