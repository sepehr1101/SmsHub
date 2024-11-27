using Moq;
using Xunit;
using AutoMapper;
using FluentValidation;
using System.Threading;
using SmsHub.Application.Features.Line.Handlers.Commands.Create.Implementations;
using SmsHub.Persistence.Features.Line.Commands.Contracts;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Domain.Constants;
using SmsHub.Application.Exceptions;
using FluentValidation.Results;
using SmsHub.Domain.Features.Entities;

public class LineCreateHandlerTests
{
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<ILineCommandService> _mockLineCommandService;
    private readonly Mock<IValidator<CreateLineDto>> _mockValidator;
    private readonly LineCreateHandler _handler;

    public LineCreateHandlerTests()
    {
        _mockMapper = new Mock<IMapper>();
        _mockLineCommandService = new Mock<ILineCommandService>();
        _mockValidator = new Mock<IValidator<CreateLineDto>>();

        _handler = new LineCreateHandler(
            _mockMapper.Object,
            _mockLineCommandService.Object,
            _mockValidator.Object
        );
    }

    [Fact]
    public async Task Handle_ValidData_ShouldNotThrowException()
    {
        var validLine = new CreateLineDto
        {
            ProviderId = ProviderEnum.Magfa,
            Number = "123456789",
            Credential = "{'Domain': 'sample', 'UserName': 'user', 'ClientSecret': 'secret'}"
        };

        var result = _handler.Handle(validLine, CancellationToken.None);
        Assert.NotNull( result );


    }

    
}

