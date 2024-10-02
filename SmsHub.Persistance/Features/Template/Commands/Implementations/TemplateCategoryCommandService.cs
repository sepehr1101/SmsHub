using SmsHub.Persistence.Contexts.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Features.Template.Commands.Contracts;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Template.Commands.Implementations
{
    public class TemplateCategoryCommandService: ITemplateCategoryCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<TemplateCategory> _templateCategories;
        public TemplateCategoryCommandService(IUnitOfWork uow)
        {
            _uow=uow;
            _templateCategories = _uow.Set<TemplateCategory>();
        }
        public async Task Add(TemplateCategory templateCategory)
        {
            await _templateCategories.AddAsync(templateCategory);
        }
        public async Task Add(ICollection<TemplateCategory> templateCategories)
        {
            await _templateCategories.AddRangeAsync(templateCategories);
        }
        public void Delete(TemplateCategory templateCategory)
        {
            _templateCategories.Remove(templateCategory);
        }
    }
}
