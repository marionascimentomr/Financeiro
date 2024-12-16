using API.Transactions.Application;
using API.Transactions.Application.Interfaces;
using API.Transactions.Message;
using Pay.Api.Extensions;
using Pay.Domain.Interfaces.Repositories;
using Pay.Domain.Interfaces.Services;
using Pay.Domain.Services;
using Pay.Infra.Data.Repositories;
using Pay.Infra.IoC.Extensions;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextConfig(builder.Configuration);

builder.Services.AddSwaggerDoc();
builder.Services.AddJwtBearer(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCorsPolicy();

builder.Services.AddTransient<ITransactionService, TransactionService>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<RabbitMqProducerService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
