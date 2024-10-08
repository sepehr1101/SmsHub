using AutoMapper;
using SmsHub.Application.Features.Template.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Template.Commands.Contracts;
using SmsHub.Persistence.Features.Template.Queries.Contracts;

namespace SmsHub.Application.Features.Template.Handlers.Commands.Delete.Implementations
{
    public class TemplateDeleteHandler:  ITemplateDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly ITemplateCommandService _templateCommandService;
        private readonly ITemplateQueryService _templateQueryService;
        public TemplateDeleteHandler(
            IMapper mapper,
            ITemplateCommandService templateCommandService,
            ITemplateQueryService templateQueryService)
        {
            _mapper=mapper;
            _mapper.NotNull(nameof(mapper));

            _templateCommandService=templateCommandService; 
            _templateCommandService.NotNull(nameof(templateQueryService));

            _templateQueryService=templateQueryService;
            _templateQueryService.NotNull(nameof(templateQueryService));
        }
        public async Task Handle(DeleteTemplateDto deleteTemplateDto, CancellationToken cancellationToken)
        {
            var template = await _templateQueryService.Get(deleteTemplateDto.Id);
            _templateCommandService.Delete(template);
        }
    }
}
