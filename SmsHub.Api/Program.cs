using SmsHub.Api.Extensions;
using SmsHub.Api.Middlewares;
using SmsHub.Application.Extensions;
using SmsHub.Common.Extensions;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.BaseHttp.Client.Implementation;
using SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts;
using SmsHub.Infrastructure.Providers.Kavenegar.Http.Implementations;
using SmsHub.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// DI
builder.Services.AddHttpClient();
builder.Services.AddScoped<IRestClient, RestClient>();
builder.Services.AddScoped<IKavenegarHttpDateService,KavenegarHttpDateService>();
builder.Services.AddScoped<IKavenegarHttpSendSimpleService,KavenegarHttpSendSimpleService>();
builder.Services.AddPersistenceInjections();
builder.Services.AddApplicationInjections();
builder.Services.AddCommonInjections();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerService();
builder.Services.UpdateDb(string.Empty);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.AddSwaggerApp();
}

app.UseMiddleware<ApiKeyMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
