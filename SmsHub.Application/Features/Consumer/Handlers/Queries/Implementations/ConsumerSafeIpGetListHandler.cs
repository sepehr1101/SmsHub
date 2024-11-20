using AutoMapper;
using SmsHub.Application.Features.Consumer.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Consumer.Queries.Contracts;

namespace SmsHub.Application.Features.Consumer.Handlers.Queries.Implementations
{
    public class ConsumerSafeIpGetListHandler: IConsumerSafeIpGetListHandler
    {
        private readonly IMapper _mapper;
        private readonly IConsumerSafeIpQueryService _consumerSafeIpQueryService;
        public ConsumerSafeIpGetListHandler(IMapper mapper, IConsumerSafeIpQueryService consumerSafeIpQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _consumerSafeIpQueryService = consumerSafeIpQueryService;
            _consumerSafeIpQueryService.NotNull(nameof(consumerSafeIpQueryService));
        }
        public async Task<ICollection<GetConsumerSafaIpDto>> Handle()
        {
            var consumerSafaIps = await _consumerSafeIpQueryService.Get();
            return _mapper.Map<ICollection<GetConsumerSafaIpDto>>(consumerSafaIps);
        }
    }
}
