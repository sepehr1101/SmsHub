using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Template.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Constants;

namespace SmsHub.Persistence.Features.Template.Queries.Implementations
{
    public class TemplateCategoryQueryService: ITemplateCategoryQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<TemplateCategory> _templateCategories;
        public TemplateCategoryQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _templateCategories = _uow.Set<TemplateCategory>();
            _templateCategories.NotNull(nameof(_templateCategories));
        }
        public async Task<ICollection<TemplateCategory>> Get()
        {
            return await _templateCategories.ToListAsync();
        }
        public async Task<TemplateCategory> Get(ProviderEnum id)
        {
            return await _uow.FindOrThrowAsync<TemplateCategory>(id);
        }
    }
}
