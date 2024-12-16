﻿namespace Pay.Api.Extensions
{
    public static class CorsExtension
    {
        private static readonly string _policyName = "DefaultPolicy";
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(s => s.AddPolicy(_policyName, builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));
            return services;
        }
        public static IApplicationBuilder UseCorsPolicy(this IApplicationBuilder app)
        {
            app.UseCors(_policyName);
            return app;
        }
    }
}
