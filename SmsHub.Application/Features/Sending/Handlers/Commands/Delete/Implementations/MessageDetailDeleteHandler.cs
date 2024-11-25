using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Sending.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Delete.Implementations
{
    public class MessageDetailDeleteHandler : IMessageDetailDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageDetailCommandService _messageDetailCommandService;
        private readonly IMessagesDetailQueryService _messagesDetailQueryService;
        private readonly IValidator<DeleteMessageDetailDto> _validator;
        public MessageDetailDeleteHandler(
            IMapper mapper,
            IMessageDetailCommandService messageDetailCommandService,
            IMessagesDetailQueryService messagesDetailQueryService,
            IValidator<DeleteMessageDetailDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messageDetailCommandService = messageDetailCommandService;
            _messageDetailCommandService.NotNull(nameof(messageDetailCommandService));

            _messagesDetailQueryService = messagesDetailQueryService;
            _messagesDetailQueryService.NotNull(nameof(messagesDetailQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(DeleteMessageDetailDto deleteMessageDetailDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(deleteMessageDetailDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var messageDetail = await _messagesDetailQueryService.Get(deleteMessageDetailDto.Id);
            _messageDetailCommandService.Delete(messageDetail);
        }
    }
}
