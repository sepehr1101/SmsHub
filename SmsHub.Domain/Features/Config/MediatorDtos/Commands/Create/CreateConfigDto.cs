using MediatR;

namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create
{
    public record CreateConfigDto : IRequest//todo: record or class?
    {//todo : null or not?
        public int ConfigTypeGroupId { get; set; }
        public int TemplateId { get; set; }
    }
}
