using AutoMapper;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Sending.Factories;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Receiving.Entities;
using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Persistence.Features.Line.Queries.Contracts;
using SmsHub.Persistence.Features.Receiving.Commands.Contracts;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Implementations
{
    public class ReceiveManagerCreateHandler : IReceiveManagerCreateHandler
    {
        private readonly ILineQueryService _lineQueryService;
        private readonly ISmsProviderFactory _smsProviderFactory;
        private readonly IReceiveCommandService _receiveCommandService;
        private readonly IProviderResponseStatusQueryService _responseStatusQueryService;
        private readonly IMapper _mapper;

        public ReceiveManagerCreateHandler(
            ILineQueryService lineQueryService,
            ISmsProviderFactory smsProviderFactory,
            IReceiveCommandService receiveCommandService,
            IMapper mapper,
             IProviderResponseStatusQueryService responseStatusQueryService)
        {
            _lineQueryService = lineQueryService;
            _lineQueryService.NotNull(nameof(lineQueryService));

            _smsProviderFactory = smsProviderFactory;
            _smsProviderFactory.NotNull(nameof(smsProviderFactory));

            _receiveCommandService = receiveCommandService;
            _receiveCommandService.NotNull(nameof(receiveCommandService));

            _responseStatusQueryService = responseStatusQueryService;
            _responseStatusQueryService.NotNull(nameof(responseStatusQueryService));
            
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));


        }
        public async Task<ICollection<Received>> Handle(int lineId)
        {
            var statusList = await _responseStatusQueryService.Get();
            var line = await GetLine(lineId);
            var smsProvider = _smsProviderFactory.Create(line.ProviderId);
            var receiveMessageDto = await smsProvider.Receive(line, statusList);
            var receiveMessages = _mapper.Map<ICollection<Received>>(receiveMessageDto);

            var receive = await _receiveCommandService.Add(receiveMessages);

            return receive;
        }


       
        private async Task<Entities.Line> GetLine(int lineId)
        {
            var line = await _lineQueryService.GetIncludeProvider(lineId);
            if (line == null)
                throw new InvalidLineException();

            return line;
        }
    }
}
