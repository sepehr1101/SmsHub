using AutoMapper;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Template.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Template.Queries.Contracts;

namespace SmsHub.Application.Features.Template.Handlers.Queries.Implementations
{
    public class TemplateGetSingleHandler: ITemplateGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly ITemplateQueryService _templateQueryService;
        public TemplateGetSingleHandler(IMapper mapper, ITemplateQueryService templateQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _templateQueryService = templateQueryService;
            _templateQueryService.NotNull(nameof(templateQueryService));
        }
        public async Task<GetTemplateDto> Handle(IntId Id)
        {
            var template = await _templateQueryService.Get(Id.Id);
            return _mapper.Map<GetTemplateDto>(template);
        }
    }
}
