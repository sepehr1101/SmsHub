using AutoMapper;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Features.Template.Commands.Contracts;
using SmsHub.Application.Features.Template.Handlers.Commands.Create.Contracts;
using System.Text.RegularExpressions;
using System.Dynamic;
using Newtonsoft.Json;
using FluentValidation;
using SmsHub.Persistence.Features.Template.Services.Contracts;
using SmsHub.Persistence.Features.Config.Commands.Contracts;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Application.Exceptions;

namespace SmsHub.Application.Features.Template.Handlers.Commands.Create.Implementations
{
    public class TemplateCreateHandler : ITemplateCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly ITemplateCommandService _templateCommandService;
        private readonly IValidator<CreateTemplateDto> _validator;
        private readonly ICheckDisallowedPhraseService _checkDisallowedPhraseService;
        private readonly IConfigCommandService _configCommandService;

        public TemplateCreateHandler(
            IMapper mapper,
            IUnitOfWork uow,
            ITemplateCommandService templateCommandService,
            IValidator<CreateTemplateDto> validator,
            ICheckDisallowedPhraseService checkDisallowedPhraseService,
            IConfigCommandService configCommandService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _templateCommandService = templateCommandService;
            _templateCommandService.NotNull(nameof(_templateCommandService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));

            _checkDisallowedPhraseService = checkDisallowedPhraseService;
            _checkDisallowedPhraseService.NotNull(nameof(_checkDisallowedPhraseService));

            _configCommandService = configCommandService;
            _configCommandService.NotNull(nameof(_configCommandService));
        }
        public async Task Handle(CreateTemplateDto createTemplateDto, CancellationToken cancellationToken)
        {
            
            await CheckValidator(createTemplateDto, cancellationToken);

            await _checkDisallowedPhraseService.Check(createTemplateDto.Expression);


            var template = _mapper.Map<Entities.Template>(createTemplateDto);
            var parameters = GetTemplateVariables(template.Expression);
            template.Parameters = parameters.Replace("\"", "'");
            var result = await _templateCommandService.Add(template);


            await AddConfig(createTemplateDto, result);
            await _uow.SaveChangesAsync(cancellationToken);

        }
        private async Task AddConfig(CreateTemplateDto request, Entities.Template template)
        {
            if (request.ConfigTypeGroupId is not null)
            {
                var config = new Entities.Config()
                {
                    ConfigTypeGroupId = request.ConfigTypeGroupId.Value,
                    Template = template
                };
                await _configCommandService.Add(config);
            }
        }
        private async Task CheckValidator(CreateTemplateDto createTemplateDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(createTemplateDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new FluentValidationException(message);
            }
        }
        private string GetTemplateVariables(string template)
        {
            var variableNames = Regex.Matches(template, @"\{([^}]+)")
              .Cast<Match>()
              .SelectMany(m => Enumerable.Range(1, m.Groups.Count - 1)
              .Select(i => m.Groups[i].Value))
              .Distinct();
            var json = GetJsonString(variableNames);
            return json;
        }

        private string GetJsonString(IEnumerable<string> variableNames)
        {
            dynamic expando = new ExpandoObject();
            var dictionary = (IDictionary<string, object>)expando;
            for (int i = 0; i < variableNames.Count(); i++)
            {
                dictionary.Add(variableNames.ElementAt(i), string.Empty);
            }
            var json = JsonConvert.SerializeObject(dictionary);
            return json;
        }
    }
}