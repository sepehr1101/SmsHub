﻿using AutoMapper;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Features.Template.Commands.Contracts;
using SmsHub.Application.Features.Template.Handlers.Commands.Create.Contracts;
using System.Text.RegularExpressions;
using System.Dynamic;
using Newtonsoft.Json;
using FluentValidation;

namespace SmsHub.Application.Features.Template.Handlers.Commands.Create.Implementations
{
    public class TemplateCreateHandler : ITemplateCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly ITemplateCommandService _templateCommandService;
        private readonly IValidator<CreateTemplateDto> _validator;
        public TemplateCreateHandler(
            IMapper mapper,
            ITemplateCommandService templateCommandService, 
            IValidator<CreateTemplateDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _templateCommandService = templateCommandService;
            _templateCommandService.NotNull(nameof(_templateCommandService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }
        public async Task Handle(CreateTemplateDto request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var template = _mapper.Map<Entities.Template>(request);
            var parameters = GetTemplateVariables(template.Expression);
            template.Parameters =parameters.Replace("\"","'");
            await _templateCommandService.Add(template);
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