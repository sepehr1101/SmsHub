using AutoMapper;
using SmsHub.Application.Features.Line.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Line.Commands.Contracts;
using SmsHub.Persistence.Features.Line.Queries.Contracts;

namespace SmsHub.Application.Features.Line.Handlers.Commands.Delete.Implementations
{
    public class ProviderDeleteHandler : IProviderDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IProviderCommandService _providerCommandService;
        private readonly IProviderQueryService _providerQueryService;
        public ProviderDeleteHandler(
            IMapper mapper,
            IProviderCommandService providerCommandService,
            IProviderQueryService providerQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull();

            _providerCommandService = providerCommandService;
            _providerCommandService.NotNull(nameof(providerCommandService));

            _providerQueryService = providerQueryService;
            _providerQueryService.NotNull(nameof(providerQueryService));
        }
        public async Task Handle(DeleteProviderDto deleteProviderDto, CancellationToken cancellationToken)
        {
            var provider = await _providerQueryService.Get(deleteProviderDto.Id);
            _providerCommandService.Delete(provider);
        }
    }
}
