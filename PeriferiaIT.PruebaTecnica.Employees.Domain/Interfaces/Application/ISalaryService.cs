using PeriferiaIT.PruebaTecnica.Employees.Domain.Common;

namespace PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces
{
    public interface ISalaryService
    {
        public decimal CalculateSalary(decimal salary, JobPosition position);
    }
}
