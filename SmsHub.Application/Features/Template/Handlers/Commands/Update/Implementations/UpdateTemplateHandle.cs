using AutoMapper;
using SmsHub.Application.Features.Template.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Features.Template.Queries.Contracts;

namespace SmsHub.Application.Features.Template.Handlers.Commands.Update.Implementations
{
    public  class UpdateTemplateHandle: IUpdateTemplateHandle
    {
        private readonly IMapper _mapper;
        private readonly ITemplateQueryService _templateQueryService;
        public UpdateTemplateHandle(IMapper mapper, ITemplateQueryService templateQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _templateQueryService = templateQueryService;
            _templateQueryService.NotNull(nameof(templateQueryService));
        }
        public async Task Handle(UpdateTemplateDto updateTemplateDto, CancellationToken cancellationToken)
        {
            var template = await _templateQueryService.Get(updateTemplateDto.Id);
            _mapper.Map(updateTemplateDto, template);
        }
    }
}
