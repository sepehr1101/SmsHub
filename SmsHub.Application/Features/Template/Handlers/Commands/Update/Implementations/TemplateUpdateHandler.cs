using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Template.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Template.Queries.Contracts;

namespace SmsHub.Application.Features.Template.Handlers.Commands.Update.Implementations
{
    public class TemplateUpdateHandler : ITemplateUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly ITemplateQueryService _templateQueryService;
        private readonly IValidator<UpdateTemplateDto> _validator;
        public TemplateUpdateHandler(
            IMapper mapper,
            ITemplateQueryService templateQueryService, 
            IValidator<UpdateTemplateDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _templateQueryService = templateQueryService;
            _templateQueryService.NotNull(nameof(templateQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(UpdateTemplateDto updateTemplateDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateTemplateDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var template = await _templateQueryService.Get(updateTemplateDto.Id);
            _mapper.Map(updateTemplateDto, template);
        }
    }
}
