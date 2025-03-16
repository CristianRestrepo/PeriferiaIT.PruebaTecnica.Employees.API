using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;
using PeriferiaIT.PruebaTecnica.Employees.Infraestructure.Repository;

namespace PeriferiaIT.PruebaTecnica.Employees.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {            
            services.AddDbContext<EmployeeDBContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionString:EmployeeDB"] ?? "");
            });

            
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            return services;
        }
    }
}
