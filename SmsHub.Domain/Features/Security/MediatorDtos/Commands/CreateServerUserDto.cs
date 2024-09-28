using MediatR;
using SmsHub.Domain.Features.Security.Dtos;

namespace SmsHub.Domain.Features.Security.MediatorDtos.Commands
{
    public class CreateServerUserDto : IRequest<ApiKeyAndHash>
    {
        public string Username { get; set; } = null!;
        public bool IsAdmin { get; set; }
    }
}
