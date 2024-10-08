using AutoMapper;
using SmsHub.Application.Features.Consumer.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Consumer.Queries.Contracts;

namespace SmsHub.Application.Features.Consumer.Handlers.Queries.Implementations
{
    public class ConsumerLineGetListHandler : IConsumerLineGetListHandler
    {
        private readonly IMapper _mapper;
        private readonly IConsumerLineQueryService _consumerLineQueryService;
        public ConsumerLineGetListHandler(IMapper mapper, IConsumerLineQueryService consumerLineQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _consumerLineQueryService = consumerLineQueryService;
            _consumerLineQueryService.NotNull(nameof(consumerLineQueryService));
        }
        public async Task<ICollection<GetConsumerLineDto>> Handle()
        {
            var consumerLines = await _consumerLineQueryService.Get();
            return _mapper.Map<ICollection<GetConsumerLineDto>>(consumerLines);
        }
    }
}
