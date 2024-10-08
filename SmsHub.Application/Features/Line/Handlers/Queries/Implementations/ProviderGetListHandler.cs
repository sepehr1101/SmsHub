using AutoMapper;
using SmsHub.Application.Features.Line.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Line.Queries.Contracts;

namespace SmsHub.Application.Features.Line.Handlers.Queries.Implementations
{
    public class ProviderGetListHandler: IProviderGetListHandler
    {
        private readonly IMapper _mapper;
        private readonly IProviderQueryService _providerQueryService;
        public ProviderGetListHandler(IMapper mapper, IProviderQueryService providerQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _providerQueryService = providerQueryService;
            _providerQueryService.NotNull(nameof(providerQueryService));
        }
        public async Task<ICollection<GetProviderDto>> Handle()
        {
            var providers = await _providerQueryService.Get();
            return _mapper.Map<ICollection<GetProviderDto>>(providers);
        }
    }
}
