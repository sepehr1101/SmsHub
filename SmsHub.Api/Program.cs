using SmsHub.Api.Extensions;
using SmsHub.Api.Middlewares;
using SmsHub.Application.Extensions;
using SmsHub.Application.Features.Contact.Handlers.Commands.Create.Contracts;
using SmsHub.Application.Features.Contact.Handlers.Commands.Create.Implementations;
using SmsHub.Common.Extensions;
using SmsHub.Infrastructure.Extensions;
using SmsHub.Persistence.Extensions;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;
using SmsHub.Persistence.Features.Contact.Commands.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();


// DI
builder.Services.AddCommonInjections();
builder.Services.AddInfrastructureInjections();
builder.Services.AddPersistenceInjections();
builder.Services.AddApplicationInjections();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerService();
builder.Services.UpdateAndSeedDb();
builder.AddHangfire();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.AddSwaggerApp();
    app.UseDeveloperExceptionPage();    
}
//app.UseMiddleware<ErrorHandlerMiddleware>();

//app.UseMiddleware<ApiKeyMiddleware>();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.AddHangfireDashboard();

//app.MapControllers();



app.Run();

public partial class Program { }
