using MediatR;

namespace SmsHub.Domain.Features.Config.PersistenceDto.Commands
{
    public record CreateDisallowedPhraseDto : IRequest//todo: record or class?
    {//todo : null or not?
        public int ConfigTypeGroupId { get; set; }
        public string Phrase { get; set; } 
    }
}
