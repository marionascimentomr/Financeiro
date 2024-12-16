using Microsoft.Extensions.DependencyInjection;
using Pay.Application.Interfaces;
using Pay.Application.Services;
using Pay.Domain.Interfaces.Repositories;
using Pay.Domain.Interfaces.Services;
using Pay.Domain.Services;
using Pay.Infra.Data.Repositories;

namespace Pay.Infra.IoC.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IAuthAppService, AuthAppService>();
            services.AddTransient<IUserAppService, UserAppService>();
            services.AddTransient<IUserDomainService, UserDomainService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
