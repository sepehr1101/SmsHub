using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Template.Commands.Contracts;

namespace SmsHub.Application.Features.Template.Handlers.Commands.Create
{
    public class CreateTemplateCategoryCommandHandler : IRequestHandler<CreateTemplateCategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly ITemplateCategoryCommandService _templateCategoryCommandService;
        public CreateTemplateCategoryCommandHandler(IMapper mapper, ITemplateCategoryCommandService templateCategoryCommandService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _templateCategoryCommandService = templateCategoryCommandService;
            _templateCategoryCommandService.NotNull(nameof(_templateCategoryCommandService));
        }

        public async Task Handle(CreateTemplateCategoryDto request, CancellationToken cancellationToken)
        {
            var templateCategory = _mapper.Map<Entities.TemplateCategory>(request);
            await _templateCategoryCommandService.Add(templateCategory);
        }
    }
}
