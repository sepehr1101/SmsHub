using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.BaseHttp.Client.Implementation;
using SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts;
using SmsHub.Infrastructure.Providers.Kavenegar.Http.Implementations;
using SmsHub.Persistence.Contexts.Implementation;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// DI
builder.Services.AddHttpClient();
builder.Services.AddScoped<IRestClient, RestClient>();
builder.Services.AddScoped<IKavenegarHttpDateService,KavenegarHttpDateService>();
builder.Services.AddScoped<IKavenegarHttpSendSimpleService,KavenegarHttpSendSimpleService>();
builder.Services.AddScoped<IUnitOfWork,TestContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.UpdateDb(string.Empty);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
