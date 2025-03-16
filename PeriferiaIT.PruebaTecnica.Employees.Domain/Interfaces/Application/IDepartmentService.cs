using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Dto;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Entities;

namespace PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Application
{
    public interface IDepartmentService
    {
        public Task<DepartmentDto> AddDepartment(AddDepartmentDto department);

        public Task<bool> DeleteDepartment(int id);

        public Task<DepartmentDto?> GetDepartment(int id);

        public Task<IEnumerable<DepartmentDto>> GetDepartments();

        public Task<IEnumerable<EmployeeDto>> GetEmployeesByDepartment(int id);

        public Task UpdateDepartment(DepartmentDto department);

    }
}
