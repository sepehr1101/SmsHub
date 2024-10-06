using AutoMapper;
using SmsHub.Application.Features.Consumer.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Consumer.Queries.Contracts;

namespace SmsHub.Application.Features.Consumer.Handlers.Queries.Implementations
{
    public class ConsumerGetSingleHandler: IConsumerGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly IConsumerQueryService _consumerQueryService;
        public ConsumerGetSingleHandler(IMapper mapper, IConsumerQueryService consumerQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _consumerQueryService = consumerQueryService;
            _consumerQueryService.NotNull(nameof(consumerQueryService));
        }
        public async Task<GetConsumerDto> Handle(int Id)
        {
           var consumer= await _consumerQueryService.Get(Id);
            return _mapper.Map<GetConsumerDto>(consumer);
        }
    }
}
