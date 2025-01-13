using AutoMapper;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Sending.Factories;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Receiving.Entities;
using SmsHub.Persistence.Features.Line.Queries.Contracts;
using SmsHub.Persistence.Features.Receiving.Commands.Contracts;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Implementations
{
    public class ReceiveManagerCreateHandler : IReceiveManagerCreateHandler
    {
        private readonly ILineQueryService _lineQueryService;
        private readonly ISmsProviderFactory _smsProviderFactory;
        private readonly IReceiveCommandService _receiveCommandService;
        private readonly IMapper _mapper;

        public ReceiveManagerCreateHandler(
            ILineQueryService lineQueryService,
            ISmsProviderFactory smsProviderFactory,
            IReceiveCommandService receiveCommandService,
            IMapper mapper)
        {
            _lineQueryService = lineQueryService;
            _lineQueryService.NotNull(nameof(lineQueryService));

            _smsProviderFactory = smsProviderFactory;
            _smsProviderFactory.NotNull(nameof(smsProviderFactory));

            _receiveCommandService = receiveCommandService;
            _receiveCommandService.NotNull(nameof(receiveCommandService));

            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

        }
        public async Task Handle(int lineId)
        {
            var line = await GetLine(lineId);
            var smsProvider = _smsProviderFactory.Create(line.ProviderId);
            var receiveMessageDto = await smsProvider.Receive(line);
            var reciveMessages= _mapper.Map<Receive>(receiveMessageDto);

            await _receiveCommandService.Add(reciveMessages);
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
