using AutoMapper;
using SmsHub.Application.Features.Config.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Config.Commands.Contracts;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Delete.Implementations
{
    public class CcSendDeleteHandler: ICcSendDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly ICcSendCommandService _ccSendCommandService;
        private readonly ICcSendQueryService _ccSendQueryService;
        public CcSendDeleteHandler(
            IMapper mapper,
            ICcSendCommandService ccSendCommandService,
            ICcSendQueryService ccSendQueryService)
        {
            _mapper=mapper;
            _mapper.NotNull(nameof(mapper));

            _ccSendCommandService=ccSendCommandService;
            _ccSendCommandService.NotNull(nameof(ccSendQueryService));

            _ccSendQueryService=ccSendQueryService;
            _ccSendQueryService.NotNull(nameof(ccSendQueryService));
        }
        public async Task Handle(DeleteCcSendDto deleteCcSendDto, CancellationToken cancellationToken)
        {
            var ccSend=await _ccSendQueryService.Get(deleteCcSendDto.Id);
            _ccSendCommandService.Delete(ccSend);
        }
    }
}
