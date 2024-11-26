using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Consumer.MediatorDtos;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Consumer.Queries.Contracts;
using System.Threading;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Update.Implementations
{
    public class ConsumerUpdateHandler : IConsumerUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IConsumerQueryService _consumerQueryService;
        private readonly IValidator<UpdateConsumerDto> _validator;
        public ConsumerUpdateHandler(IMapper mapper, IConsumerQueryService consumerQueryService, IValidator<UpdateConsumerDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _consumerQueryService = consumerQueryService;
            _consumerQueryService.NotNull(nameof(consumerQueryService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }
        public async Task Handle(UpdateConsumerDto updateConsumerDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateConsumerDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var consumer = await _consumerQueryService.Get(updateConsumerDto.Id);
            _mapper.Map(updateConsumerDto, consumer);
        }
    }
}
