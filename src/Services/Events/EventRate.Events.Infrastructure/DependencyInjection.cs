using EventRate.Events.Domain.Base;
using EventRate.Events.Infrastructure.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace EventRate.Events.Infrastructure
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationContext>(options =>
            {
                string sqlConStr = configuration.GetConnectionString("DefaultConnection");
                options.UseNpgsql(sqlConStr, b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)); 

            }); 


            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }


    }
}
