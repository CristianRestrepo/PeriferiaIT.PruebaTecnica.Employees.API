using AutoMapper;
using Moq;
using PeriferiaIT.PruebaTecnica.Employees.Application.Employees.Commands;
using PeriferiaIT.PruebaTecnica.Employees.Application.Mapper;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriferiaIT.PruebaTecnica.Employees.Test.Application
{
    public sealed class CreateEmployeeCommandHandlerTest
    {
        private readonly Mock<IEmployeeRepository> _employeeRepository;
        private readonly Mock<ISalaryService> _salaryService;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandlerTest()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();
            _salaryService = new Mock<ISalaryService>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            _mapper = new Mapper(config);
        }

        [Fact]
        public async Task Handle_ValidInput_ReturnsCreatedEmployee()
        {
            // Arrange

            _salaryService.Setup(s => s.CalculateSalary(It.IsAny<decimal>(), It.IsAny<PruebaTecnica.Employees.Domain.Common.JobPosition>()))
                .Returns((decimal salary, PruebaTecnica.Employees.Domain.Common.JobPosition position) =>
                {
                    return position switch
                    {
                        PruebaTecnica.Employees.Domain.Common.JobPosition.Developer => salary * 1.1m,
                        PruebaTecnica.Employees.Domain.Common.JobPosition.Manager => salary * 1.2m,
                        PruebaTecnica.Employees.Domain.Common.JobPosition.HR => salary,
                        PruebaTecnica.Employees.Domain.Common.JobPosition.Sales => salary,
                        _ => salary
                    };
                });

            var command = new CreateEmployeeCommand
            {
                Name = "John Doe",
                Salary = 5000,
                Position = PruebaTecnica.Employees.Domain.Common.JobPosition.Developer,
                DepartmentId = 1,
                Email = "correoprueba@hotmail.com"
            };
            var handler = new CreateEmployeeCommandHandler(_employeeRepository.Object, _mapper, _salaryService.Object);
            // Act
            var result = await handler.Handle(command, CancellationToken.None);
            // Assert
            Assert.NotNull(result);
            Assert.Equal("John Doe", result.Name);
            Assert.Equal(5500, result.Salary);
            Assert.Equal(PruebaTecnica.Employees.Domain.Common.JobPosition.Developer, result.Position);
        }
    }
}
