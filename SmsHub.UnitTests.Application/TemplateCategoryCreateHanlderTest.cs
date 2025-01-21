using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using SmsHub.Application.Features.Template.Handlers.Commands.Create.Implementations;
using SmsHub.Persistence.Contexts.Implementation;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;
using FluentValidation;
using AutoMapper;
using SmsHub.Persistence.Features.Template.Commands.Implementations;
using SmsHub.Persistence.Features.Template.Commands.Contracts;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace SmsHub.UnitTests.Application
{
    public class TemplateCategoryCreateHanlertTest
    {

    }
    /*public class TemplateCategoryCreateHanlderTest : IClassFixture<_TestEnvironmentWebApplicationFactory>
{
   private readonly IServiceScopeFactory _scopeFactory;

   public TemplateCategoryCreateHanlderTest(_TestEnvironmentWebApplicationFactory factory)
   {
       _scopeFactory = factory.Services.GetRequiredService<IServiceScopeFactory>();
   }

   [Fact]
   public async Task Handle_ShouldCreateTemplateCategoryInDatabase()
   {
       // Arrange: تنظیم وابستگی‌ها
       using var scope = _scopeFactory.CreateScope();
       var dbContext = scope.ServiceProvider.GetRequiredService<SmsHubContext>();
       var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
       var validator = scope.ServiceProvider.GetRequiredService<IValidator<CreateTemplateCategoryDto>>();

       var unitOfWork =BaseDbContext;
       var commandService = new ITemplateCategoryCommandService();

       var handler = new TemplateCategoryCreateHandler(mapper, commandService, validator);

       var request = new CreateTemplateCategoryDto
       {
           Title = "Test Category",
           Description = "Test Description"
       };

       // Act: فراخوانی متد Handle
       await handler.Handle(request, CancellationToken.None);

       // Assert: بررسی ذخیره شدن داده در پایگاه داده
       var savedCategory = await dbContext.TemplateCategories.FirstOrDefaultAsync(c => c.Title == "Test Category");
       Assert.NotNull(savedCategory);
       Assert.Equal("Test Description", savedCategory.Description);
   }
}*/
}

