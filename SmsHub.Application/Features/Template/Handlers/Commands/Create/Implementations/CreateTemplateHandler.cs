using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Template.Commands.Contracts;
using SmsHub.Application.Features.Template.Handlers.Commands.Create.Contracts;
using HandlebarsDotNet;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.Dynamic;
using System;
using Newtonsoft.Json;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Template.Handlers.Commands.Create.Implementations
{
    public class CreateTemplateHandler : ICreateTemplateHandler
    /*: IRequestHandler<CreateTemplateDto>*/
    {
        private readonly IMapper _mapper;
        private readonly ITemplateCommandService _templateCommandService;
        public CreateTemplateHandler(IMapper mapper, ITemplateCommandService templateCommandService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _templateCommandService = templateCommandService;
            _templateCommandService.NotNull(nameof(_templateCommandService));
        }
        public async Task Handle(CreateTemplateDto request, CancellationToken cancellationToken)
        {
            var template = _mapper.Map<Entities.Template>(request);
            template.Parameters = GetTemplateVariables(template.Expression);
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
            var json= JsonConvert.SerializeObject(dictionary);
            return json;
        }
    }
}