using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Sending.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Delete.Implementations
{
    public class MessageStateCategoryDeleteHandler : IMessageStateCategoryDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageStateCategoryCommandService _messageStateCategoryCommandService;
        private readonly IMessageStateCategoryQueryService _messageStateCategoryQueryService;
        private readonly IValidator<DeleteMessageStateCategoryDto> _validator;
        public MessageStateCategoryDeleteHandler(
            IMapper mapper,
            IMessageStateCategoryCommandService messageStateCategoryCommandService,
            IMessageStateCategoryQueryService messageStateCategoryQueryService,
            IValidator<DeleteMessageStateCategoryDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messageStateCategoryCommandService = messageStateCategoryCommandService;
            _messageStateCategoryCommandService.NotNull(nameof(messageStateCategoryCommandService));

            _messageStateCategoryQueryService = messageStateCategoryQueryService;
            _messageStateCategoryQueryService.NotNull(nameof(messageStateCategoryQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(DeleteMessageStateCategoryDto deleteMessageStateCategoryDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(deleteMessageStateCategoryDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var messageStateCategory = await _messageStateCategoryQueryService.Get(deleteMessageStateCategoryDto.Id);
            _messageStateCategoryCommandService.Delete(messageStateCategory);
        }
    }
}
