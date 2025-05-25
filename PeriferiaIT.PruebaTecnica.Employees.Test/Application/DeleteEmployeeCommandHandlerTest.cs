using Moq;
using PeriferiaIT.PruebaTecnica.Employees.Application.Employees.Commands;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Entities;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;

namespace PeriferiaIT.PruebaTecnica.Employees.Test.Application
{
    public sealed class DeleteEmployeeCommandHandlerTest
    {
        private readonly Mock<IEmployeeRepository> _employeeRepository;
        public DeleteEmployeeCommandHandlerTest()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();
        }

        [Fact]
        public async Task DeleteEmployeeCommandHandler_ShouldDeleteEmployee_WhenEmployeeExists()
        {
            // Arrange

            _employeeRepository
                .Setup(repo => repo.DeleteEmployee(It.IsAny<int>(), default))
                .ReturnsAsync(true);

            var employeeId = 1;
            var command = new DeleteEmployeeCommand() { Id = employeeId };
            var handler = new DeleteEmployeeCommandHandler(_employeeRepository.Object);
            // Act
            var result = await handler.Handle(command, CancellationToken.None);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteEmployeeCommandHandler_WhenEmployeeDoesNotExist()
        {
            // Arrange
            _employeeRepository
            .Setup(repo => repo.DeleteEmployee(It.IsAny<int>(), default))
            .ReturnsAsync(false);

            var nonExistentEmployeeId = 2;
            var command = new DeleteEmployeeCommand() { Id = nonExistentEmployeeId };
            var handler = new DeleteEmployeeCommandHandler(_employeeRepository.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);
            // Assert
            Assert.False(result);
        }
    }
}
