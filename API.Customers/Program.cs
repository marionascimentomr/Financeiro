using API.Customers.Application;
using API.Customers.Application.Interfaces;
using API.Customers.Message;
using Microsoft.Extensions.Caching.Memory;
using Pay.Api.Extensions;
using Pay.Domain.Interfaces.Repositories;
using Pay.Domain.Interfaces.Services;
using Pay.Domain.Services;
using Pay.Infra.Data.Repositories;
using Pay.Infra.IoC.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Configura��es de servi�os
builder.Services.AddDbContextConfig(builder.Configuration);
builder.Services.AddSwaggerDoc();
builder.Services.AddJwtBearer(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCorsPolicy();

// Inje��o de depend�ncias
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<ICustomerDomainService, CustomerDomainService>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddMemoryCache();
builder.Services.AddTransient<ICacheService, CacheService>();
builder.Services.AddSingleton<RabbitMqConsumerService>();
builder.Services.AddHostedService<Worker>(); // Registra o Worker como servi�o hospedado

// Constr�i a aplica��o
var app = builder.Build();

// Configura middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerDoc();
app.UseCorsPolicy();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
