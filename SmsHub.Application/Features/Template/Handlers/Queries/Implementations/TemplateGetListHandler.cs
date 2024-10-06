using AutoMapper;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Template.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Template.Queries.Contracts;

namespace SmsHub.Application.Features.Template.Handlers.Queries.Implementations
{
    public class TemplateGetListHandler: ITemplateGetListHandler
    {
        private readonly IMapper _mapper;
        private readonly ITemplateQueryService _templateQueryService;
        public TemplateGetListHandler(IMapper mapper    ,ITemplateQueryService templateQueryService)
        {
            _mapper=mapper;
            _mapper.NotNull(nameof(mapper));

            _templateQueryService = templateQueryService;
            _templateQueryService.NotNull(nameof(templateQueryService));
        }
        public async Task<ICollection<GetTemplateDto>> Handle()
        {
            var templates = await _templateQueryService.Get();
            return _mapper.Map<ICollection<GetTemplateDto>>(templates);
        }
    }
}
