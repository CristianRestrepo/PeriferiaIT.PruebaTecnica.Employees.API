using PeriferiaIT.PruebaTecnica.Employees.Domain.Common;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces;

namespace PeriferiaIT.PruebaTecnica.Employees.Domain.Services
{
    public class SalaryService : ISalaryService
    {
        public decimal CalculateSalary(decimal salary, JobPosition position)
        {            
            decimal bonus = 0;
            if (position == Domain.Common.JobPosition.Developer)
            {
                bonus = (salary * 10) / 100;
            }
            else if (position == Domain.Common.JobPosition.Manager)
            {
                bonus = (salary * 20) / 100; ;
            }
            return salary = bonus;
        }
    }
}
