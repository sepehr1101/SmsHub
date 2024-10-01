using SmsHub.Domain.Constants;

namespace SmsHub.Domain.Features.Line.MediatorDtos.Commands
{
    public class UpdateLineDto
    {//todo: check Prop
        public int Id { get; set; }
        public ProviderEnum ProviderId { get; set; }
        public string Number { get; set; } = null!;
        public string Credential { get; set; } = null!;
    }
}
