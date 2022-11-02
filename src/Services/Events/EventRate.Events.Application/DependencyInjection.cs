using AutoMapper;
using EventRate.Events.Application.Mappers;
using EventRate.Events.Application.PipelineBehaviors;
using EventRate.Events.Infrastructure;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace EventRate.Events.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            #region Configure Mapper

            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod is not null && (p.GetMethod.IsPublic || p.GetMethod.IsAssembly);
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper();

            #endregion

            services.AddInfrastructure(configuration);

            return services;
        }
    }
}
