using AutoMapper;
using SmsHub.Application.Features.Consumer.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Consumer.Queries.Contracts;

namespace SmsHub.Application.Features.Consumer.Handlers.Queries.Implementations
{
    public class ConsumerSafeIpGetSingleHandler : IConsumerSafeIpGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly IConsumerSafeIpQueryService _consumerSafeIpQueryService;
        public ConsumerSafeIpGetSingleHandler(
            IMapper mapper, 
            IConsumerSafeIpQueryService consumerSafeIpQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _consumerSafeIpQueryService = consumerSafeIpQueryService;
            _consumerSafeIpQueryService.NotNull(nameof(consumerSafeIpQueryService));
        }
        public async Task<GetConsumerSafaIpDto> Handle(IntId Id)
        {
            var consumerSafeIp = await _consumerSafeIpQueryService.Get(Id.Id);
            return _mapper.Map<GetConsumerSafaIpDto>(consumerSafeIp);
        }
    }
}
