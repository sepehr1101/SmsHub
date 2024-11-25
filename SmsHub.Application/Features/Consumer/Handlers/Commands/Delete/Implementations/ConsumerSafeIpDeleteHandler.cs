using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Consumer.Commands.Contracts;
using SmsHub.Persistence.Features.Consumer.Queries.Contracts;
using System.Threading;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Delete.Implementations
{
    public class ConsumerSafeIpDeleteHandler : IConsumerSafeIpDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IConsumerSafeIpCommandService _consumerSafeIpCommandService;
        private readonly IConsumerSafeIpQueryService _consumerSafeIpQueryService;
        private readonly IValidator<DeleteConsumerSafeIpDto> _validator;

        public ConsumerSafeIpDeleteHandler(
            IMapper mapper,
            IConsumerSafeIpCommandService consumerSafeIpCommandService,
            IConsumerSafeIpQueryService consumerSafeIpQueryService,
            IValidator<DeleteConsumerSafeIpDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _consumerSafeIpCommandService = consumerSafeIpCommandService;
            _consumerSafeIpCommandService.NotNull(nameof(consumerSafeIpCommandService));

            _consumerSafeIpQueryService = consumerSafeIpQueryService;
            _consumerSafeIpQueryService.NotNull(nameof(consumerSafeIpQueryService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }
        public async Task Handle(DeleteConsumerSafeIpDto deleteConsumerSafeIpDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(deleteConsumerSafeIpDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var consumerSafeIp = await _consumerSafeIpQueryService.Get(deleteConsumerSafeIpDto.Id);
            _consumerSafeIpCommandService.Delete(consumerSafeIp);
        }
    }
}
