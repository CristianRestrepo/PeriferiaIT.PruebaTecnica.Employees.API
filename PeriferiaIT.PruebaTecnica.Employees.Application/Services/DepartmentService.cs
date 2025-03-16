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
    class DepartmentService(IDepartmentRepository _repository, IEmployeeRepository _employeeRepository ,IMapper _mapper) : IDepartmentService
    {
        public async Task<DepartmentDto> AddDepartment(AddDepartmentDto department)
        {
            Department newDepartment = _mapper.Map<Department>(department);
            await _repository.AddDepartment(newDepartment);
            return _mapper.Map<DepartmentDto>(newDepartment);
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            return await _repository.DeleteDepartment(id);
        }

        public async Task<DepartmentDto> GetDepartment(int id)
        {
            var department = await _repository.GetDepartment(id);
            return _mapper.Map<DepartmentDto>(department);  
        }

        public async Task<IEnumerable<DepartmentDto>> GetDepartments()
        {
            var departments = await _repository.GetDepartments();
            return _mapper.Map<IEnumerable<DepartmentDto>>(departments);
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesByDepartment(int id)
        {
            var employees = await _employeeRepository.GetEmployees();
            IEnumerable<Employee> employeesByDepartment = employees.Where(x => x.DepartmentId.Equals(id)).AsEnumerable();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employeesByDepartment);
        }

        public async Task UpdateDepartment(DepartmentDto department)
        {
            await _repository.UpdateDepartment(_mapper.Map<Department>(department));
        }
    }
}
