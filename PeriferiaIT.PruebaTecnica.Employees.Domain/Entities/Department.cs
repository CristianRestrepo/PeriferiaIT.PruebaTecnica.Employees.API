using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriferiaIT.PruebaTecnica.Employees.Domain.Entities
{
    public class Department : Base
    {
        public ICollection<Employee> Employees { get; set; }
    }
}
