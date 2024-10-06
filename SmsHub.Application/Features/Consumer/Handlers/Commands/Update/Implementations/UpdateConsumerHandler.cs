using AutoMapper;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Features.Consumer.Queries.Contracts;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Update.Implementations
{
    public class UpdateConsumerHandler: IUpdateConsumerHandler
    {
        private readonly IMapper _mapper;
        private readonly IConsumerQueryService _consumerQueryService;
        public UpdateConsumerHandler(IMapper mapper, IConsumerQueryService consumerQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _consumerQueryService = consumerQueryService;
            _consumerQueryService.NotNull(nameof(consumerQueryService));
        }
        public async Task Handle(UpdateConsumerDto updateConsumerDto, CancellationToken cancellationToken)
        {
            var consumer = await _consumerQueryService.Get(updateConsumerDto.Id);
            _mapper.Map(updateConsumerDto, consumer);
        }
    }
}
