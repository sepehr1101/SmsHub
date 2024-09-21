using AutoMapper;
using MediatR;
using SmsHub.Common;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Logging.Commands.Contracts;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Create
{
   public class CreateInformativeLogCommandHandler:IRequestHandler<CreateInformativeLogDto>
    {
        private readonly IMapper _mapper;
        private readonly IInformativeLogCommandService _informativeLogCommandService;
        public CreateInformativeLogCommandHandler(IMapper mapper, IInformativeLogCommandService informativeLogCommandService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _informativeLogCommandService = informativeLogCommandService;
            _informativeLogCommandService.NotNull(nameof(_informativeLogCommandService));
        }

        public async Task Handle(CreateInformativeLogDto request, CancellationToken cancellationToken)
        {
           var informativeLog=_mapper.Map<Entities.InformativeLog>(request);
            await _informativeLogCommandService.Add(informativeLog);
        }
    }
}
