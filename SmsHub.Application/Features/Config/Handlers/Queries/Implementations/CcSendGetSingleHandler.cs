using AutoMapper;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Queries.Implementations
{
    public class CcSendGetSingleHandler : ICcSendGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly ICcSendQueryService _ccSendQueryService;
        public CcSendGetSingleHandler(ICcSendQueryService ccSendQueryService, IMapper mapper)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _ccSendQueryService = ccSendQueryService;
            _ccSendQueryService.NotNull(nameof(ccSendQueryService));
        }
        public async Task<GetCcSendDto> Handle(IntId Id)
        {
            var ccSend = await _ccSendQueryService.Get(Id.Id);
            return _mapper.Map<GetCcSendDto>(ccSend);
        }
    }
}
