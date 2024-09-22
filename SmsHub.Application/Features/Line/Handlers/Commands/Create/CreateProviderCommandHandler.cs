using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Line.Commands.Contracts;

namespace SmsHub.Application.Features.Line.Handlers.Commands.Create
{
    public class CreateProviderCommandHandler : IRequestHandler<CreateProviderDto>
    {
        private readonly IMapper _mapper;
        private readonly IProviderCommandService _providerCommandService;
        public CreateProviderCommandHandler(IMapper mapper, IProviderCommandService providerCommandService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _providerCommandService = providerCommandService;
            _providerCommandService.NotNull(nameof(_providerCommandService));
        }

        public async Task Handle(CreateProviderDto request, CancellationToken cancellationToken)
        {
            var provider = _mapper.Map<Entities.Provider>(request);
            await _providerCommandService.Add(provider);
        }
    }
}
