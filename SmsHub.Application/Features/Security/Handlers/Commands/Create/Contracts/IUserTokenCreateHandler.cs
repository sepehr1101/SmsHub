using SmsHub.Domain.Features.Security.Dtos;

namespace SmsHub.Application.Features.Auth.Handlers.Commands.Create.Contracts
{
    public interface IUserTokenCreateHandler
    {
        Task Handle(JwtTokenData jwtTokenData, string? refreshTokenSourceSerial, CancellationToken cancellationToken);
    }
}