using AutoMapper;
using MediatR;
using Moq;
using PeriferiaIT.PruebaTecnica.Employees.Application.Employees.Commands;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Common;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Entities;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;

namespace PeriferiaIT.PruebaTecnica.Employees.Test.Application
{
    public class UpdateEmployeeCommandHandlerTest
    {
        private readonly Mock<IEmployeeRepository> _employeeRepository;
        private readonly Mock<IMapper> _mapper;
        public UpdateEmployeeCommandHandlerTest()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();
            _mapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task Handle_Should_Call_UpdateEmployee_And_Return_Unit()
        {
            // Arrange

            var command = new UpdateEmployeeCommand
            {
                Id = 1,
                Name = "Juan Pérez",
                Email = "juan.perez@email.com",
                Salary = 3000m,
                Position = JobPosition.Developer,
                DepartmentId = 2
            };

            var employee = new Employee
            {
                Name = command.Name,
                Email = command.Email,
                Salary = command.Salary,
                Position = command.Position,
                DepartmentId = command.DepartmentId
            };

            _mapper.Setup(m => m.Map<Employee>(command)).Returns(employee);
            _employeeRepository.Setup(r => r.UpdateEmployee(employee, It.IsAny<CancellationToken>()))
                          .Returns(Task.CompletedTask);

            var handler = new UpdateEmployeeCommandHandler(_employeeRepository.Object, _mapper.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            _mapper.Verify(m => m.Map<Employee>(command), Times.Once);
            _employeeRepository.Verify(r => r.UpdateEmployee(employee, It.IsAny<CancellationToken>()), Times.Once);
            Assert.Equal(Unit.Value, result);
        }
    }
}
