using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Pay.Domain.Interfaces.Security;
using Pay.Infra.Security.Services;
using Pay.Infra.Security.Settings;
using System.Text;

namespace Pay.Infra.IoC.Extensions
{
    public static class JwtBearerExtension
    {
        public static IServiceCollection AddJwtBearer(this IServiceCollection services, 
            IConfiguration configuration)
        {
            var issuer = configuration.GetSection("TokenSettings:Issuer").Value;
            var audience = configuration.GetSection("TokenSettings:Audience").Value;
            var secretKey = configuration.GetSection("TokenSettings:SecretKey").Value;

            var expirationInMinutes = int.Parse(configuration.GetSection
                ("TokenSettings:ExpirationInMinutes").Value);

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true, 
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))

                };
            });
            services.Configure<TokenSettings>(configuration.GetSection("TokenSettings"));
            services.AddTransient<ITokenService, TokenService>();

            return services;
        }
    }
}
