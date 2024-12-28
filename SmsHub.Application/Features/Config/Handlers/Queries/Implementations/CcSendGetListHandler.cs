using AutoMapper;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Queries.Implementations
{
    public class CcSendGetListHandler : ICcSendGetListHandler
    {
        private readonly IMapper _mapper;
        private readonly ICcSendQueryService _ccSendQueryService;
        public CcSendGetListHandler(
            IMapper mapper,
            ICcSendQueryService ccSendQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _ccSendQueryService = ccSendQueryService;
            _ccSendQueryService.NotNull(nameof(ccSendQueryService));
        }
        public async Task<ICollection<GetCcSendDto>> Handle()
        {
            var ccSends = await _ccSendQueryService.Get();
            return _mapper.Map<ICollection<GetCcSendDto>>(ccSends);
        }
    }
}
