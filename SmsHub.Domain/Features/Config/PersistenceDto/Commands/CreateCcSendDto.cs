using MediatR;

namespace SmsHub.Domain.Features.Config.PersistenceDto.Commands
{
    public record CreateCcSendDto : IRequest//todo: record or class?
    { //todo : null or not?
        public int ConfigTypeGroupId { get; set; }
        public string Mobile { get; set; } 
    }
}
