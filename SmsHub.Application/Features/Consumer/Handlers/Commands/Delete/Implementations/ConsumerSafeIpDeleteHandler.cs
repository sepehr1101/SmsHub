using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Consumer.Commands.Contracts;
using SmsHub.Persistence.Features.Consumer.Queries.Contracts;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Delete.Implementations
{
    public class ConsumerSafeIpDeleteHandler : IConsumerSafeIpDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IConsumerSafeIpCommandService _consumerSafeIpCommandService;
        private readonly IConsumerSafeIpQueryService _consumerSafeIpQueryService;
        public ConsumerSafeIpDeleteHandler(
            IMapper mapper,
            IConsumerSafeIpCommandService consumerSafeIpCommandService,
            IConsumerSafeIpQueryService consumerSafeIpQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _consumerSafeIpCommandService = consumerSafeIpCommandService;
            _consumerSafeIpCommandService.NotNull(nameof(consumerSafeIpCommandService));

            _consumerSafeIpQueryService = consumerSafeIpQueryService;
            _consumerSafeIpQueryService.NotNull(nameof(consumerSafeIpQueryService));
        }
        public async Task Handle(DeleteConsumerSafeIpDto deleteConsumerSafeIpDto, CancellationToken cancellationToken)
        {
            var consumerSafeIp = await _consumerSafeIpQueryService.Get(deleteConsumerSafeIpDto.Id);
            _consumerSafeIpCommandService.Delete(consumerSafeIp);
        }
    }
}
