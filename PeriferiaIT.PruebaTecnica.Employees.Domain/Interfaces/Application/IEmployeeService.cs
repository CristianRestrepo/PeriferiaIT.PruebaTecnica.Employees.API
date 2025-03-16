using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Dto;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Entities;

namespace PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Application
{
    public interface IEmployeeService
    {
        public Task<EmployeeDto> AddEmployee(AddEmployeeDto employee);

        public Task<bool> DeleteEmployee(int id);

        public Task<EmployeeDto?> GetEmployee(int id);

        public Task<IEnumerable<EmployeeDto>> GetEmployees();

        public Task UpdateEmployee(EmployeeDto employee);
    }
}
