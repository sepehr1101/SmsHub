using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Template.Commands.Contracts;

namespace SmsHub.Application.Features.Template.Handlers.Commands.Create
{
    public class CreateTemplateCommandHandler : IRequestHandler<CreateTemplateDto>
    {
        private readonly IMapper _mapper;
        private readonly ITemplateCommandService _templateCommandService;
        public CreateTemplateCommandHandler(IMapper mapper, ITemplateCommandService templateCommandService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _templateCommandService = templateCommandService;
            _templateCommandService.NotNull(nameof(_templateCommandService));
        }
        public async Task Handle(CreateTemplateDto request, CancellationToken cancellationToken)
        {
            var template = _mapper.Map<Entities.Template>(request);
            await _templateCommandService.Add(template);
        }
    }
}
