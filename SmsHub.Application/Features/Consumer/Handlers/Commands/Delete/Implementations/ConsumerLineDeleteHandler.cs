using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Consumer.Commands.Contracts;
using SmsHub.Persistence.Features.Consumer.Queries.Contracts;
using System.Threading;

namespace SmsHub.Application.Features.Consumer.Handlers.Commands.Delete.Implementations
{
    public class ConsumerLineDeleteHandler : IConsumerLineDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IConsumerLineCommandService _consumerLineCommandService;
        private readonly IConsumerLineQueryService _consumerLineQueryService;
        public ConsumerLineDeleteHandler(
            IMapper mapper,
            IConsumerLineCommandService consumerLineCommandService,
            IConsumerLineQueryService consumerLineQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _consumerLineCommandService = consumerLineCommandService;
            _consumerLineCommandService.NotNull(nameof(consumerLineCommandService));

            _consumerLineQueryService = consumerLineQueryService;
            _consumerLineQueryService.NotNull(nameof(consumerLineQueryService));
        }
        public async Task Handle(DeleteConsumerLineDto deleteConsumerLineDto, CancellationToken cancellationToken)
        {
            var consumerLine = await _consumerLineQueryService.Get(deleteConsumerLineDto.Id);
            _consumerLineCommandService.Delete(consumerLine);
        }
    }
}
