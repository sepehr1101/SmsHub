using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Sending.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
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
        private readonly IValidator<UpdateMessageDetailStatusDto> _validator;

        public MessageDetailStatusUpdateHandler(
            IMapper mapper,
            IMessageDetailStatusCommandService messageDetailStatusCommandService,
            IMessageDetailStatusQueryService messageDetailStatusQueryService,
            IValidator<UpdateMessageDetailStatusDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messageDetailStatusCommandService = messageDetailStatusCommandService;
            _messageDetailStatusCommandService.NotNull(nameof(messageDetailStatusCommandService));

            _messageDetailStatusQueryService= messageDetailStatusQueryService;
            _messageDetailStatusQueryService.NotNull(nameof(messageDetailStatusQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }

        public async Task Handle(UpdateMessageDetailStatusDto updateMessageDetailStatusDto, CancellationToken cancellationToken)
        {
            await CheckValidator(updateMessageDetailStatusDto,cancellationToken);

            var messageDetailStatus=await _messageDetailStatusQueryService.GetById(updateMessageDetailStatusDto.Id);
            if (messageDetailStatus != null)
            {
                _mapper.Map(updateMessageDetailStatusDto, messageDetailStatus);
            }
            throw new InvalidDataException();
        }
        private async Task CheckValidator(UpdateMessageDetailStatusDto updateMessageDetailStatusDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateMessageDetailStatusDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }
        }


    }
}
