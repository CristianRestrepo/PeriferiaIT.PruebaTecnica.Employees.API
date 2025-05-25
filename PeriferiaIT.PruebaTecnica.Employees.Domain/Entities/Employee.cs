using PeriferiaIT.PruebaTecnica.Employees.Domain.Common;

namespace PeriferiaIT.PruebaTecnica.Employees.Domain.Entities
{
    public class Employee : Base
    {
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public JobPosition Position { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
