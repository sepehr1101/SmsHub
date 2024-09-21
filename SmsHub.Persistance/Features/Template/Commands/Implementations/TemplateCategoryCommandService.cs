using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Features.Template.Commands.Contracts;

namespace SmsHub.Persistence.Features.Template.Commands.Implementations
{
    public class TemplateCategoryCommandService: ITemplateCategoryCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.TemplateCategory> _templateCategories;
        public TemplateCategoryCommandService(IUnitOfWork uow)
        {
            _uow=uow;
            _templateCategories = _uow.Set<Entities.TemplateCategory>();
        }
        public async Task Add(Entities.TemplateCategory templateCategory)
        {
            await _templateCategories.AddAsync(templateCategory);
        }
        public async Task Add(ICollection<Entities.TemplateCategory> templateCategories)
        {
            await _templateCategories.AddRangeAsync(templateCategories);
        }
    }
}
