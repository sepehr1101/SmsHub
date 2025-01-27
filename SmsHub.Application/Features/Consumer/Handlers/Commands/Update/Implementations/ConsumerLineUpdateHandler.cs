using AutoMapper;
using FluentValidation;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Consumer.Queries.Contracts;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Update.Implementations
{
    public class ConsumerLineUpdateHandler : IConsumerLineUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IConsumerLineQueryService _consumerLineQueryService;
        private readonly IValidator<UpdateConsumerLineDto> _validator;

        public ConsumerLineUpdateHandler(
            IMapper mapper, 
            IConsumerLineQueryService consumerLineQueryService, 
            IValidator<UpdateConsumerLineDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(Mapper));

            _consumerLineQueryService = consumerLineQueryService;
            _consumerLineQueryService.NotNull(nameof(consumerLineQueryService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }
        public async Task Handle(UpdateConsumerLineDto updateConsumerLineDto, CancellationToken cancellationToken)
        {
            await CheckValidator(updateConsumerLineDto, cancellationToken);

            var consumerLine = await _consumerLineQueryService.Get(updateConsumerLineDto.Id);
            _mapper.Map(updateConsumerLineDto, consumerLine);
        }
        private async Task CheckValidator(UpdateConsumerLineDto updateConsumerLineDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateConsumerLineDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new FluentValidationException(message);
            }
        }


    }
}
