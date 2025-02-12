﻿using AutoMapper;
using FluentValidation;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Sending.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Update.Implementations
{
    public class MessageBatchUpdateHandler : IMessageBatchUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageBatchQueryService _messageBatchQueryService;
        private readonly IValidator<UpdateMessageBatchDto> _validator;
        public MessageBatchUpdateHandler(
            IMapper mapper,
            IMessageBatchQueryService messageBatchQueryService, 
            IValidator<UpdateMessageBatchDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messageBatchQueryService = messageBatchQueryService;
            _messageBatchQueryService.NotNull(nameof(messageBatchQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(UpdateMessageBatchDto updateMessageBatchDto, CancellationToken cancellationToken)
        {
            await CheckValidator(updateMessageBatchDto, cancellationToken);

            var messageBatch = await _messageBatchQueryService.Get(updateMessageBatchDto.Id);
            _mapper.Map(updateMessageBatchDto, messageBatch);
        }
        private async Task CheckValidator(UpdateMessageBatchDto updateMessageBatchDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateMessageBatchDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new FluentValidationException(message);
            }
        }


    }
}
