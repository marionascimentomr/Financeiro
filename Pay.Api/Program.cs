using Pay.Api.Extensions;
using Pay.Infra.IoC.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddSwaggerDoc();
builder.Services.AddJwtBearer(builder.Configuration);
builder.Services.AddDependencyInjection();
builder.Services.AddAutoMapperConfig();
builder.Services.AddDbContextConfig(builder.Configuration);
builder.Services.AddCorsPolicy();

var app = builder.Build();

app.UseSwaggerDoc();
app.UseCorsPolicy();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
