using SmsHub.Domain.Constants;

namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands
{
    public class DeleteMessageHolderDto
    {
        public ProviderEnum Id { get; set; }
    }
}
