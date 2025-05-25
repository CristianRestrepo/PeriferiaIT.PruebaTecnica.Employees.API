using PeriferiaIT.PruebaTecnica.Employees.Domain.Entities;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Services;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PeriferiaIT.PruebaTecnica.Employees.Test.Domain
{
    
    public sealed class SalaryServiceTest
    {

        [Fact]
        public void CalculateSalary_ValidInput_ReturnsCorrectSalary_Developer()
        {
            // Arrange
            var salaryService = new SalaryService();
            var employee = new Employee(){Name = "Cristian Restrepo", Salary = 1000, Position = PruebaTecnica.Employees.Domain.Common.JobPosition.Developer};
            // Act
            var result = salaryService.CalculateSalary(employee.Salary, employee.Position);
            // Assert
            Assert.AreEqual(1100, result);
        }

        [Fact]
        public void CalculateSalary_ValidInput_ReturnsCorrectSalary_Manager()
        {
            // Arrange
            var salaryService = new SalaryService();
            var employee = new Employee() { Name = "Cristian Restrepo", Salary = 1000, Position = PruebaTecnica.Employees.Domain.Common.JobPosition.Manager };
            // Act
            var result = salaryService.CalculateSalary(employee.Salary, employee.Position);
            // Assert
            Assert.AreEqual(1200, result);
        }

        [Fact]
        public void CalculateSalary_ValidInput_ReturnsCorrectSalary_HR()
        {
            // Arrange
            var salaryService = new SalaryService();
            var employee = new Employee() { Name = "Cristian Restrepo", Salary = 1000, Position = PruebaTecnica.Employees.Domain.Common.JobPosition.HR };
            // Act
            var result = salaryService.CalculateSalary(employee.Salary, employee.Position);
            // Assert
            Assert.AreEqual(1000, result);
        }

        [Fact]
        public void CalculateSalary_ValidInput_ReturnsCorrectSalary_Sales()
        {
            // Arrange
            var salaryService = new SalaryService();
            var employee = new Employee() { Name = "Cristian Restrepo", Salary = 1000, Position = PruebaTecnica.Employees.Domain.Common.JobPosition.Sales };
            // Act
            var result = salaryService.CalculateSalary(employee.Salary, employee.Position);
            // Assert
            Assert.AreEqual(1000, result);
        }
    }
}
