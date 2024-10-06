using AutoMapper;
using SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Update.Implementations
{
    public class UpdateCcSendHandler: IUpdateCcSendHandler
    {
        private readonly IMapper _mapper;
        private readonly ICcSendQueryService _cSendQueryService;
        public UpdateCcSendHandler(IMapper mapper, ICcSendQueryService cSendQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _cSendQueryService = cSendQueryService;
            _cSendQueryService.NotNull(nameof(cSendQueryService));
        }
        public async Task Handle(UpdateCcSendDto updateCcSendDto, CancellationToken cancellationToken)
        {
            var ccSend=await _cSendQueryService.Get(updateCcSendDto.Id);
            _mapper.Map(updateCcSendDto, ccSend);
        }
    }
}
