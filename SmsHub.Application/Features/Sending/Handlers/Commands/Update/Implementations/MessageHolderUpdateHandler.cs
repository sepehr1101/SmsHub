using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Sending.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Update.Implementations
{
    public class MessageHolderUpdateHandler : IMessageHolderUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessagesHolderQueryService _messagesHolderQueryService;
        private readonly IValidator<UpdateMessageHolderDto> _validator;
        public MessageHolderUpdateHandler(IMapper mapper, IMessagesHolderQueryService messagesHolderQueryService, IValidator<UpdateMessageHolderDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messagesHolderQueryService = messagesHolderQueryService;
            _messagesHolderQueryService.NotNull(nameof(messagesHolderQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(UpdateMessageHolderDto updateMessageHolderDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateMessageHolderDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var messageHolder = await _messagesHolderQueryService.Get(updateMessageHolderDto.Id);
            _mapper.Map(updateMessageHolderDto, messageHolder);
        }
    }
}
