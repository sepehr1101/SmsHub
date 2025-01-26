using AutoMapper;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using FluentValidation;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Implementations
{
    public class MessageStateCategoryCreateHandler : IMessageStateCategoryCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageStateCategoryCommandService _messageStateCategoryCommandService;
        private readonly IValidator<CreateMessageStateCategoryDto> _validator;
        public MessageStateCategoryCreateHandler(
            IMapper mapper, 
            IMessageStateCategoryCommandService messageStateCategoryCommandService, 
            IValidator<CreateMessageStateCategoryDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _messageStateCategoryCommandService = messageStateCategoryCommandService;
            _messageStateCategoryCommandService.NotNull(nameof(_messageStateCategoryCommandService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }

        public async Task Handle(CreateMessageStateCategoryDto createMessageStateCategoryDto, CancellationToken cancellationToken)
        {
            await CheckValidator(createMessageStateCategoryDto, cancellationToken);

            var messageStateCategory = _mapper.Map<Entities.MessageStateCategory>(createMessageStateCategoryDto);
            await _messageStateCategoryCommandService.Add(messageStateCategory);
        }
        private async Task CheckValidator(CreateMessageStateCategoryDto createMessageStateCategoryDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(createMessageStateCategoryDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }
        }


    }
}
