using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Common;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Entities;

namespace PeriferiaIT.PruebaTecnica.Employees.Domain.Dto
{
    public class EmployeeDto : Base
    {      
        public required string Email { get; set; }
        public decimal Salary { get; set; }
        public JobPosition Position { get; set; }
        public required int DepartmentId { get; set; }
    }
}
