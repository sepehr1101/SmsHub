using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Sending.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Update.Implementations
{
    public class MessageDetailUpdateHandler : IMessageDetailUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessagesDetailQueryService _messagesDetailQueryService;
        private readonly IValidator<UpdateMessageDetailDto> _validator;
        public MessageDetailUpdateHandler(
            IMapper mapper, 
            IMessagesDetailQueryService messagesDetailQueryService, 
            IValidator<UpdateMessageDetailDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messagesDetailQueryService = messagesDetailQueryService;
            _messagesDetailQueryService.NotNull(nameof(messagesDetailQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(UpdateMessageDetailDto updateMessageDetailDto, CancellationToken cancellationToken)
        {
            await CheckValidator(updateMessageDetailDto, cancellationToken);

            var messageDetail = await _messagesDetailQueryService.Get(updateMessageDetailDto.Id);
            _mapper.Map(updateMessageDetailDto, messageDetail);
        }
        private async Task CheckValidator(UpdateMessageDetailDto updateMessageDetailDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateMessageDetailDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }
        }


    }
}
