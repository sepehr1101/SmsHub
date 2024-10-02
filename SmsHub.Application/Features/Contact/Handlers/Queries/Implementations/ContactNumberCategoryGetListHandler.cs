using AutoMapper;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;

namespace SmsHub.Application.Features.Contact.Handlers.Queries.Implementations
{
    public class ContactNumberCategoryGetListHandler: IContactNumberCategoryGetListHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactNumberCategoryQueryService _contactNumberCategoryQueryService;
        public ContactNumberCategoryGetListHandler(IMapper mapper, IContactNumberCategoryQueryService contactNumberCategoryQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _contactNumberCategoryQueryService = contactNumberCategoryQueryService;
            _contactNumberCategoryQueryService.NotNull(nameof(contactNumberCategoryQueryService));
        }
        public async Task<ICollection<GetContactNumberCategoryDto>> Handle()
        {
            var contactNumberCategories = await _contactNumberCategoryQueryService.Get();
            return _mapper.Map<ICollection<GetContactNumberCategoryDto>>(contactNumberCategories);
        }
    }
}
