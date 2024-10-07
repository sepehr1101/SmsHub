using AutoMapper;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Consumer.Queries.Contracts;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Update.Implementations
{
    public class ConsumerSafaIpUpdateHandler: IConsumerSafaIpUpdateHandler
    {
       private readonly IMapper _mapper;
        private readonly IConsumerSafeIpQueryService _consumerSafeIpQueryService;
        public ConsumerSafaIpUpdateHandler(IMapper mapper, IConsumerSafeIpQueryService consumerSafeIpQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _consumerSafeIpQueryService = consumerSafeIpQueryService;
            _consumerSafeIpQueryService.NotNull(nameof(consumerSafeIpQueryService));
        }
        public async Task Handle(UpdateConsumerSafeIpDto updateConsumerSafeIpDto, CancellationToken cancellationToken)
        {
            var consumerSafeIp = await _consumerSafeIpQueryService.Get(updateConsumerSafeIpDto.Id);
            _mapper.Map(updateConsumerSafeIpDto, consumerSafeIp);
        }
    }
}
