
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PeriferiaIT.PruebaTecnica.Employees.Application.Mapper;
using PeriferiaIT.PruebaTecnica.Employees.Application.Services;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Dto;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Entities;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;
using Assert = Xunit.Assert;


namespace PeriferiaIT.PruebaTecnica.Employees.Test.Services
{
    public class EmployeeServiceTest 
    {
        private Mock<IEmployeeRepository> _repository;
        private static IMapper _mapper;

        public EmployeeServiceTest()
        {
            this._repository = new Mock<IEmployeeRepository>();
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapperProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }        

        [Fact]
        public async Task AddEmployeeTest_OkResult()
        {
            // Arrange
            _repository.Setup(x => x.AddEmployee(It.IsAny<Employee>())).Returns(Task.CompletedTask);
            var service = new EmployeeService(_repository.Object, _mapper);

            // Act
            var result = await service.AddEmployee(GetAddEmployeeDto());

            // Assert
            Assert.NotNull(result);
            Assert.IsType<EmployeeDto>(result);
        }

        [Fact]
        public async Task DeleteEmployee_OkResult()
        {
            // Arrange
            _repository.Setup(x => x.DeleteEmployee(It.IsAny<int>())).ReturnsAsync(true);
            var service = new EmployeeService(_repository.Object, _mapper);

            // Act
            var result = await service.DeleteEmployee(1);

            // Assert
            Assert.NotNull(result);
            Assert.True(result);
        }

        [Fact]
        public async Task GetEmployee_OkResult()
        {
            // Arrange
            _repository.Setup(x => x.GetEmployee(It.IsAny<int>())).ReturnsAsync(GetEmployee());
            var service = new EmployeeService(_repository.Object, _mapper);

            // Act
            var result = await service.GetEmployee(1);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<EmployeeDto>(result);
        }

        [Fact]
        public async Task GetEmployees_OkResult()
        {
            // Arrange
            _repository.Setup(x => x.GetEmployees()).ReturnsAsync(GetEmployees());
            var service = new EmployeeService(_repository.Object, _mapper);

            // Act
            var result = await service.GetEmployees();

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<EmployeeDto>>(result);
        }

        [Fact]
        public async Task UpdateEmployee_OkResult()
        {
            // Arrange        
            _repository.Setup(x => x.UpdateEmployee(It.IsAny<Employee>())).Returns(Task.CompletedTask);
            var service = new EmployeeService(_repository.Object, _mapper);

            // Act
            Task task = service.UpdateEmployee(GetEmployeeDto());

            // Assert
            Assert.True(task.IsCompletedSuccessfully);           
        }


        private AddEmployeeDto GetAddEmployeeDto()
        {
            return new AddEmployeeDto()
            {
                Name = "Empleado 1",
                Email = "Correo@prueba.com",
                DepartmentId = 1,
                Position = Domain.Common.JobPosition.Manager,
                Salary = 800000
            };
        }

        private EmployeeDto GetEmployeeDto()
        {
            return new EmployeeDto()
            {
                Id = 1,
                Name = "Empleado 1",
                Email = "Correo@prueba.com",
                DepartmentId = 1,
                Position = Domain.Common.JobPosition.Manager,
                Salary = 800000
            };
        }
        private IEnumerable<Employee> GetEmployees()
        {
            return new List<Employee> { GetEmployee() };
        }

        private Employee GetEmployee()
        {
            return new Employee()
            {
                Id = 1,
                Name = "Empleado 1",
                Email = "Correo@prueba.com",
                DepartmentId = 1,
                Position = Domain.Common.JobPosition.Manager,
                Salary = 800000
            };
        }
    }
}
