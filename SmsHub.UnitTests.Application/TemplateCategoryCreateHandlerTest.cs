using Microsoft.Extensions.DependencyInjection;
using Moq;
using SmsHub.Application.Features.Template.Handlers.Commands.Create.Implementations;
using SmsHub.Persistence.Features.Template.Commands.Contracts;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;
using FluentValidation;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Threading;
using System.Threading.Tasks;
using SmsHub.Persistence.Contexts.Implementation;

namespace SmsHub.UnitTests.Application
{
    public class TemplateCategoryCreateHandlerTest : IClassFixture<_TestEnvironmentWebApplicationFactory>
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public TemplateCategoryCreateHandlerTest(_TestEnvironmentWebApplicationFactory factory)
        {
            _scopeFactory = factory.Services.GetRequiredService<IServiceScopeFactory>();
        }

        [Fact]
        public async Task Handle_ShouldCreateTemplateCategoryInDatabase()
        {
            // Arrange: تنظیم وابستگی‌ها
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<SmsHubContext>();

            // Mocking وابستگی‌ها
            var mockMapper = new Mock<IMapper>();
            var mockValidator = new Mock<IValidator<CreateTemplateCategoryDto>>();
            var mockCommandService = new Mock<ITemplateCategoryCommandService>();

            var request = new CreateTemplateCategoryDto
            {
                Title = "Test Category By Xunit",
                Description = "Test Description"
            };

            mockMapper.Setup(m => m.Map<TemplateCategory>(It.IsAny<CreateTemplateCategoryDto>()))
                      .Returns(new TemplateCategory { Title = request.Title, Description = request.Description });

            mockValidator.Setup(v => v.ValidateAsync(request, It.IsAny<CancellationToken>()))
                         .ReturnsAsync(new FluentValidation.Results.ValidationResult());

            mockCommandService.Setup(service => service.Add(It.IsAny<TemplateCategory>()))
                              .Returns(Task.CompletedTask);

            var handler = new TemplateCategoryCreateHandler(mockMapper.Object, mockCommandService.Object, mockValidator.Object);

            // Act: فراخوانی متد Handle
            await handler.Handle(request, CancellationToken.None);

            // Assert: بررسی ذخیره شدن داده در پایگاه داده واقعی
            var savedCategory = await dbContext.TemplateCategories.FirstOrDefaultAsync(c => c.Title == "Test Category");
            Assert.NotNull(savedCategory);
            Assert.Equal("Test Description", savedCategory.Description);

            // Verify that Add method was called on the command service
            mockCommandService.Verify(service => service.Add(It.Is<TemplateCategory>(c => c.Title == "Test Category" && c.Description == "Test Description")), Times.Once);
        }
    }
}

