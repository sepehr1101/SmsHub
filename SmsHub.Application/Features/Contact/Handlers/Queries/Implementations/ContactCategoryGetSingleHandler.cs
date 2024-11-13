using AutoMapper;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;

namespace SmsHub.Application.Features.Contact.Handlers.Queries.Implementations
{
    public class ContactCategoryGetSingleHandler: IContactCategoryGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactCategoryQueryService _contactCategoryQueryService;
        public ContactCategoryGetSingleHandler(IMapper mapper, IContactCategoryQueryService contactCategoryQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _contactCategoryQueryService = contactCategoryQueryService;
            _contactCategoryQueryService.NotNull(nameof(contactCategoryQueryService));
        }
        public async Task<GetContactCategoryDto> Handle(IntId Id)
        {
            var contactCategory = await _contactCategoryQueryService.Get(Id.Id);
            return _mapper.Map<GetContactCategoryDto>(contactCategory);
        }
    }
}
