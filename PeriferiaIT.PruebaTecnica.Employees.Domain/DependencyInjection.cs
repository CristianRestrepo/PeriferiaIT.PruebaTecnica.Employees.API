using Microsoft.Extensions.DependencyInjection;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Interfaces;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Services;

namespace PeriferiaIT.PruebaTecnica.Employees.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddTransient<ISalaryService, SalaryService>();       
            return services;
        }
    }
}
