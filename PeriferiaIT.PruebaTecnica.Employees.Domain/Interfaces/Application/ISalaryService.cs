using PeriferiaIT.PruebaTecnica.Employees.Domain.Common;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces
{
    public interface ISalaryService
    {
        public decimal CalculateSalary(decimal salary, JobPosition position);
    }
}
