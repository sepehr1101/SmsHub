using AutoMapper;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;

namespace SmsHub.Application.Features.Contact.Handlers.Queries.Implementations
{
    public class ContactCategoryGetListHandler: IContactCategoryGetListHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactCategoryQueryService _contactCategoryQueryService;
        public ContactCategoryGetListHandler(IMapper mapper, IContactCategoryQueryService contactCategoryQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _contactCategoryQueryService = contactCategoryQueryService;
            _contactCategoryQueryService.NotNull(nameof(contactCategoryQueryService));
        }
        public async Task<ICollection<GetContactCategoryDto>> Handle()
        {
            var contactCategories = await _contactCategoryQueryService.Get();
            return _mapper.Map<ICollection<GetContactCategoryDto>>(contactCategories);
        }
    }
}
