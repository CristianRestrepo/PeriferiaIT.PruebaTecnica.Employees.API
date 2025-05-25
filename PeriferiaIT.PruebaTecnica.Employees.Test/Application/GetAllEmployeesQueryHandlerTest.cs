using AutoMapper;
using Moq;
using PeriferiaIT.PruebaTecnica.Employees.Application.Employees.Querys;
using PeriferiaIT.PruebaTecnica.Employees.Application.Mapper;
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
    public class GetAllEmployeesQueryHandlerTest
    {
        private readonly Mock<IEmployeeRepository> _repositoryMock;
        private readonly IMapper _mapper;
        private readonly GetAllEmployeesQueryHandler _handler;
        public GetAllEmployeesQueryHandlerTest()
        {
            _repositoryMock = new Mock<IEmployeeRepository>();
           
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            _mapper = new Mapper(config);

            _handler = new GetAllEmployeesQueryHandler(_repositoryMock.Object, _mapper);
        }

        [Fact]
        public async Task Handle_ReturnsMappedEmployees_WhenEmployeesExist()
        {
            // Arrange
            var employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Juan", Email = "juan@mail.com", Salary = 1000, Position = JobPosition.Developer, DepartmentId = 1 }
            };


            _repositoryMock.Setup(r => r.GetEmployees(It.IsAny<CancellationToken>()))
                .ReturnsAsync(employees);

            // Act
            var result = await _handler.Handle(new GetAllEmployeesQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Juan", result.First().Name);
            _repositoryMock.Verify(r => r.GetEmployees(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_ReturnsEmptyList_WhenNoEmployeesExist()
        {
            // Arrange
            var employees = new List<Employee>();
            var employeesDto = new List<EmployeeDto>();

            _repositoryMock.Setup(r => r.GetEmployees(It.IsAny<CancellationToken>()))
                .ReturnsAsync(employees);
            

            // Act
            var result = await _handler.Handle(new GetAllEmployeesQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            _repositoryMock.Verify(r => r.GetEmployees(It.IsAny<CancellationToken>()), Times.Once);
        }

    }
}
