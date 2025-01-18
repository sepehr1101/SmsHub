using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Security.Dtos;

namespace SmsHub.Application.Features.Security.Handlers.Commands.Create.Contracts
{
    public interface IUserLineCreateHandler
    {
        Task Handle(CreateUserLineDto createUserLineDto, CancellationToken cancellationToken);
    }
}
