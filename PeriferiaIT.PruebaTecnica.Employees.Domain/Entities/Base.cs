using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriferiaIT.PruebaTecnica.Employees.Domain.Entities
{
    public class Base
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
