using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriferiaIT.PruebaTecnica.Employees.Domain.Common
{
    [Flags]
    public enum JobPosition
    {
        Developer,
        Manager,
        HR,
        Sales
    }
}
