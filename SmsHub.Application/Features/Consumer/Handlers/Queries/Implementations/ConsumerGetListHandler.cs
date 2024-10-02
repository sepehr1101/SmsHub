using AutoMapper;
using SmsHub.Application.Features.Consumer.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Consumer.Queries.Contracts;

namespace SmsHub.Application.Features.Consumer.Handlers.Queries.Implementations
{
    public class ConsumerGetListHandler : IConsumerGetListHandler
    {
        private readonly IMapper _mapper;
        private readonly IConsumerQueryService _consumerQueryService;
        public ConsumerGetListHandler(IMapper mapper, IConsumerQueryService consumerQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _consumerQueryService = consumerQueryService;
            _consumerQueryService.NotNull(nameof(consumerQueryService));
        }
        public async Task<ICollection<GetConsumerDto>> Handle()
        {
            var consumers = await _consumerQueryService.Get();
            return _mapper.Map<ICollection<GetConsumerDto>>(consumers);
        }
    }
}
