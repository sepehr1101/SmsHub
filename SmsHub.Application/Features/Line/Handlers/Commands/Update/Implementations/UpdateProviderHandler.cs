using AutoMapper;
using SmsHub.Application.Features.Line.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Features.Line.Queries.Contracts;

namespace SmsHub.Application.Features.Line.Handlers.Commands.Delete.Implementations
{
    public class UpdateProviderHandler : IUpdateProviderHandler
    {
        private readonly IMapper _mapper;
        private readonly IProviderQueryService _providerQueryService;
        public UpdateProviderHandler(
            IMapper mapper,
            IProviderQueryService providerQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _providerQueryService = providerQueryService;
            _providerQueryService.NotNull(nameof(providerQueryService));
        }
        public async Task Handle(UpdateProviderDto updateProviderDto, CancellationToken cancellationToken)
        {
            var provider = await _providerQueryService.Get(updateProviderDto.Id);
            _mapper.Map(updateProviderDto, provider);
        }
    }
}
