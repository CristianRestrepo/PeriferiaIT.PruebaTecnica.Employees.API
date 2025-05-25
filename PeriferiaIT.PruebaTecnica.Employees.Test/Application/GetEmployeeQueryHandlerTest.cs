using AutoMapper;
using Moq;
using PeriferiaIT.PruebaTecnica.Employees.Application.Employees.Querys;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Common;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Dto;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Entities;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriferiaIT.PruebaTecnica.Employees.Test.Application
{
    public class GetEmployeeQueryHandlerTest
    {
        private readonly Mock<IEmployeeRepository> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly GetEmployeeQueryHandler _handler;

        public GetEmployeeQueryHandlerTest()
        {
            _repositoryMock = new Mock<IEmployeeRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new GetEmployeeQueryHandler(_repositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_ReturnsEmployeeDto_WhenEmployeeExists()
        {
            // Arrange
            var employeeId = 1;
            var employee = new Employee
            {
                Id = employeeId,
                Name = "Juan Pérez",
                Email = "juan@correo.com",
                Salary = 2000,
                Position = JobPosition.Developer,
                DepartmentId = 2,
                Department = new Department { Id = 2, Name = "TI" }
            };
            var employeeDto = new EmployeeDto
            {
                Id = employeeId,
                Name = "Juan Pérez",
                Email = "juan@correo.com",
                Salary = 2000,
                Position = JobPosition.Developer,
                DepartmentId = 2
            };

            _repositoryMock.Setup(r => r.GetEmployee(employeeId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(employee);
            _mapperMock.Setup(m => m.Map<EmployeeDto>(employee))
                .Returns(employeeDto);

            var query = new GetEmployeeQuery { Id = employeeId };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(employeeDto.Id, result.Id);
            Assert.Equal(employeeDto.Name, result.Name);
            Assert.Equal(employeeDto.Email, result.Email);
            Assert.Equal(employeeDto.Salary, result.Salary);
            Assert.Equal(employeeDto.Position, result.Position);
            Assert.Equal(employeeDto.DepartmentId, result.DepartmentId);
        }

        [Fact]
        public async Task Handle_ReturnsNull_WhenEmployeeDoesNotExist()
        {
            // Arrange
            var employeeId = 99;
            _repositoryMock.Setup(r => r.GetEmployee(employeeId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Employee?)null);
            _mapperMock.Setup(m => m.Map<EmployeeDto>(null))
                .Returns((EmployeeDto?)null);

            var query = new GetEmployeeQuery { Id = employeeId };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Null(result);
        }
    }
}
