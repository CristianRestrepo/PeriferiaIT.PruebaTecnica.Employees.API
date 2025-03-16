using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Dto;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Entities;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Application;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;

namespace PeriferiaIT.PruebaTecnica.Employees.Application.Services
{
    public class EmployeeService(IEmployeeRepository _repository, IMapper _mapper) : IEmployeeService
    {
        public async Task<EmployeeDto> AddEmployee(AddEmployeeDto employee)
        {
            
            Employee newEmployee = _mapper.Map<Employee>(employee);
            CalculateSalary(newEmployee);
            await _repository.AddEmployee(newEmployee);
            return _mapper.Map<EmployeeDto>(newEmployee);
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            return await _repository.DeleteEmployee(id);
        }

        public async Task<EmployeeDto?> GetEmployee(int id)
        {
            var employee = await _repository.GetEmployee(id);
            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployees()
        {
            var employees = await _repository.GetEmployees();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task UpdateEmployee(EmployeeDto employee)
        {
            await _repository.UpdateEmployee(_mapper.Map<Employee>(employee));
        }


        private void CalculateSalary(Employee employee)
        {
            decimal bono = 0;
            if (employee.Position == Domain.Common.JobPosition.Developer)
            {
                bono = (employee.Salary * 10) / 100;
            }
            else if (employee.Position == Domain.Common.JobPosition.Manager)
            {
                bono = (employee.Salary * 20) / 100; ;
            }
            employee.Salary = employee.Salary + bono;
        }
    }
}
