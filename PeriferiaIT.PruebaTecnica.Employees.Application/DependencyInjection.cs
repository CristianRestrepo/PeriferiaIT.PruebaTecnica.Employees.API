using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using PeriferiaIT.PruebaTecnica.Employees.Application.Mapper;

namespace PeriferiaIT.PruebaTecnica.Employees.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(typeof(AutoMapperProfile));
            return services;
        }
    }
}
