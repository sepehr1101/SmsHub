using AutoMapper;
using SmsHub.Application.Features.Line.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Line.Queries.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Application.Features.Line.Handlers.Queries.Implementations
{
    public class ProviderGetSingleHandler: IProviderGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly IProviderQueryService _providerQueryService;
        public ProviderGetSingleHandler(IMapper mapper, IProviderQueryService providerQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _providerQueryService = providerQueryService;
            _providerQueryService.NotNull(nameof(providerQueryService));
        }
        public async Task<GetProviderDto> Handle(ProviderEnum Id)
        {
            var providers = await _providerQueryService.Get(Id);
            return _mapper.Map<GetProviderDto>(providers);
        }
    }
}
