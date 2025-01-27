using AutoMapper;
using FluentValidation;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Sending.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Update.Implementations
{
    public class MessageStateCategoryUpdateHandler : IMessageStateCategoryUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageStateCategoryQueryService _messageStateCategoryQueryService;
        private readonly IValidator<UpdateMessageStateCategoryDto> _validator;
        public MessageStateCategoryUpdateHandler(
            IMapper mapper,
            IMessageStateCategoryQueryService messageStateCategoryQueryService,
            IValidator<UpdateMessageStateCategoryDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messageStateCategoryQueryService = messageStateCategoryQueryService;
            _messageStateCategoryQueryService.NotNull(nameof(messageStateCategoryQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(UpdateMessageStateCategoryDto updateMessageStateCategoryDto, CancellationToken cancellationToken)
        {
            await CheckValidator(updateMessageStateCategoryDto, cancellationToken);

            var messageStateCategory = await _messageStateCategoryQueryService.Get(updateMessageStateCategoryDto.Id);
            _mapper.Map(updateMessageStateCategoryDto, messageStateCategory);
        }
        private async Task CheckValidator(UpdateMessageStateCategoryDto updateMessageStateCategoryDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateMessageStateCategoryDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new FluentValidationException(message);
            }
        }


    }
}
