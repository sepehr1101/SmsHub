using AutoMapper;
using SmsHub.Application.Features.Sending.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Update.Implementations
{
    public class UpdateMessageStateCategoryHandler: IUpdateMessageStateCategoryHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageStateCategoryQueryService _messageStateCategoryQueryService;
        public UpdateMessageStateCategoryHandler(IMapper mapper, IMessageStateCategoryQueryService messageStateCategoryQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messageStateCategoryQueryService = messageStateCategoryQueryService;
            _messageStateCategoryQueryService.NotNull(nameof(messageStateCategoryQueryService));
        }
        public async Task Handle(UpdateMessageStateCategoryDto updateMessageStateCategoryDto, CancellationToken cancellationToken)

        {
            var messageStateCategory = await _messageStateCategoryQueryService.Get(updateMessageStateCategoryDto.Id);
            _mapper.Map(updateMessageStateCategoryDto, messageStateCategory);
        }
    }
}
