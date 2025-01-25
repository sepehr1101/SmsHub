using AutoMapper;
using Azure.Core;
using FluentValidation;
using SmsHub.Application.Features.Template.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Template.Queries.Contracts;
using SmsHub.Persistence.Features.Template.Services.Contracts;

namespace SmsHub.Application.Features.Template.Handlers.Commands.Update.Implementations
{
    public class TemplateUpdateHandler : ITemplateUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly ITemplateQueryService _templateQueryService;
        private readonly IValidator<UpdateTemplateDto> _validator;
        private readonly ICheckDisallowedPhraseService _checkDisallowedPhraseService;
        public TemplateUpdateHandler(
            IMapper mapper,
            ITemplateQueryService templateQueryService, 
            IValidator<UpdateTemplateDto> validator,
            ICheckDisallowedPhraseService checkDisallowedPhraseService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _templateQueryService = templateQueryService;
            _templateQueryService.NotNull(nameof(templateQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));

            _checkDisallowedPhraseService = checkDisallowedPhraseService;
            _checkDisallowedPhraseService.NotNull(nameof(checkDisallowedPhraseService));
        }
        public async Task Handle(UpdateTemplateDto updateTemplateDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateTemplateDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }
            //checking
            await _checkDisallowedPhraseService.Check(updateTemplateDto.Expression);


            var template = await _templateQueryService.Get(updateTemplateDto.Id);
            _mapper.Map(updateTemplateDto, template);
        }
    }
}
