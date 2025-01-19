using SmsHub.Api.Extensions;
using SmsHub.Persistence.Extensions;
using SmsHub.Api.ExceptionHandlers;
using Serilog;
using Serilog.Ui.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
// DI
builder.Services.AddDI();

builder.Services.AddCustomJwtBearer(configuration);
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerService();
builder.Services.AddCaptcha();
builder.Services.AddCustomDbContext(configuration);
builder.Services.UpdateAndSeedDb();
builder.AddHangfire();

builder.Services.AddCustomCors();
builder.Services.AddCustomOptions(configuration);

//Exceptions
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

//serilog
builder.Services.AddSerilog(configuration);

//app
var app = builder.Build();

app.UseExceptionHandler("/error");

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.AddSwaggerApp();
//}

//app.UseMiddleware<ApiKeyMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();
app.UseCustomCors();
app.UseAuthentication();
app.UseAuthorization();
app.UseSerilogUi();

app.AddHangfireDashboard();

app.MapControllers();
app.Run();

public partial class Program { }
