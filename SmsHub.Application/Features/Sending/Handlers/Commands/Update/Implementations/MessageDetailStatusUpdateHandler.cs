using AutoMapper;
using SmsHub.Application.Features.Sending.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Update.Implementations
{
    public class MessageDetailStatusUpdateHandler : IMessageDetailStatusUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageDetailStatusCommandService _messageDetailStatusCommandService;
        private readonly IMessageDetailStatusQueryService _messageDetailStatusQueryService;

        public MessageDetailStatusUpdateHandler(
            IMapper mapper,
            IMessageDetailStatusCommandService messageDetailStatusCommandService,
            IMessageDetailStatusQueryService messageDetailStatusQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messageDetailStatusCommandService = messageDetailStatusCommandService;
            _messageDetailStatusCommandService.NotNull(nameof(messageDetailStatusCommandService));

            _messageDetailStatusQueryService= messageDetailStatusQueryService;
            _messageDetailStatusQueryService.NotNull(nameof(messageDetailStatusQueryService));
        }

        public async Task Handle(UpdateMessageDetailStatusDto request, CancellationToken cancellationToken)
        {
            var messageDetailStatus=await _messageDetailStatusQueryService.GetById(request.Id);
            if (messageDetailStatus != null)
            {
                _mapper.Map(request, messageDetailStatus);
            }
            throw new InvalidDataException();
        }
    }
}
