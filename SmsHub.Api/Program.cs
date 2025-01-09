using DeviceDetectorNET.Parser.Device;
using SmsHub.Api.Extensions;
using SmsHub.Application.Extensions;
using SmsHub.Infrastructure.Extensions;
using SmsHub.Persistence.Extensions;
using SmsHub.Common.Extensions;
using SmsHub.Api.ExceptionHandlers;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
// DI
//builder.Services.AddDI();
builder.Services.AddCommonInjections();
builder.Services.AddInfrastructureInjections();
builder.Services.AddPersistenceInjections();
builder.Services.AddApplicationInjections();

builder.Services.AddCustomJwtBearer(configuration);
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

///dictionary
//builder.Services.AddScoped<Magfa>();
//builder.Services.AddScoped< Kavenegar>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerService();
builder.Services.AddCustomDbContext(configuration);
builder.Services.UpdateAndSeedDb();
builder.AddHangfire();

builder.Services.AddCustomCors();
builder.Services.AddCustomOptions(configuration);

//Exceptions
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

//app
var app = builder.Build();

app.UseExceptionHandler();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.AddSwaggerApp();
    app.UseDeveloperExceptionPage();    
//}
//app.UseMiddleware<ErrorHandlerMiddleware>();

//app.UseMiddleware<ApiKeyMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.AddHangfireDashboard();

app.MapControllers();
app.Run();

public partial class Program { }
