using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pay.Infra.Data.Contexts;

namespace Pay.Infra.IoC.Extensions
{
    public static class DbContextExtension
    {
        public static IServiceCollection AddDbContextConfig(this IServiceCollection services,
            IConfiguration configuration)
        {
            //services.AddDbContext<DataContext>(options =>
            //{
            //    options.UseInMemoryDatabase("DbPayInMemory");
            //});

            //return services;

            var connectionString = configuration.GetConnectionString("DbPay");

            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            return services;
        }
    }
}
