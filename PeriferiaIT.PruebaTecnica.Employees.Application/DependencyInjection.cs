using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PeriferiaIT.PruebaTecnica.Employees.Application.Mapper;
using PeriferiaIT.PruebaTecnica.Employees.Application.Services;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Application;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces.Repository;

namespace PeriferiaIT.PruebaTecnica.Employees.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            return services;
        }
    }
}
