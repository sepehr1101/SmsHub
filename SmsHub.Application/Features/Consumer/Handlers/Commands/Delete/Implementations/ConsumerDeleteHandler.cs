using AutoMapper;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Consumer.Commands.Contracts;
using SmsHub.Persistence.Features.Consumer.Queries.Contracts;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Delete.Implementations
{
    public class ConsumerDeleteHandler: IConsumerDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IConsumerCommandService _consumerCommandService;
        private readonly IConsumerQueryService _consumerQueryService;
        public ConsumerDeleteHandler(
            IMapper mapper,
            IConsumerCommandService consumerCommandService,
            IConsumerQueryService consumerQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _consumerCommandService = consumerCommandService;
            _consumerCommandService.NotNull(nameof(consumerCommandService));

            _consumerQueryService = consumerQueryService;
            _consumerQueryService.NotNull(nameof(consumerQueryService));
        }
        public async Task Handle(DeleteConsumerDto deleteConsumerDto, CancellationToken cancellationToken)
        {
            var consumer=await _consumerQueryService.Get(deleteConsumerDto.Id);
            _consumerCommandService.Delete(consumer);
        }
    }
}
