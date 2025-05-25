namespace PeriferiaIT.PruebaTecnica.Employees.Domain.Entities
{
    public class Department : Base
    {
        public ICollection<Employee> Employees { get; set; }
    }
}
