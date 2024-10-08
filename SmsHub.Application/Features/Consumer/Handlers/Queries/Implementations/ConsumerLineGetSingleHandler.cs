using AutoMapper;
using SmsHub.Application.Features.Consumer.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Consumer.Queries.Contracts;

namespace SmsHub.Application.Features.Consumer.Handlers.Queries.Implementations
{
    public class ConsumerLineGetSingleHandler : IConsumerLineGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly IConsumerLineQueryService _consumerLineQueryService;
        public ConsumerLineGetSingleHandler(IMapper mapper, IConsumerLineQueryService consumerLineQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _consumerLineQueryService = consumerLineQueryService;
            _consumerLineQueryService.NotNull(nameof(consumerLineQueryService));
        }
        public async Task<GetConsumerLineDto> Handle(int Id)
        {
            var consumerLines = await _consumerLineQueryService.Get(Id);
            return _mapper.Map<GetConsumerLineDto>(consumerLines);
        }
    }
}
