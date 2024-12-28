using AutoMapper;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;

namespace SmsHub.Application.Features.Contact.Handlers.Queries.Implementations
{
    public class ContactNumberCategoryGetSingleHandler: IContactNumberCategoryGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactNumberCategoryQueryService _contactNumberCategoryQueryService;
        public ContactNumberCategoryGetSingleHandler(
            IMapper mapper, 
            IContactNumberCategoryQueryService contactNumberCategoryQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _contactNumberCategoryQueryService = contactNumberCategoryQueryService;
            _contactNumberCategoryQueryService.NotNull(nameof(contactNumberCategoryQueryService));
        }
        public async Task<GetContactNumberCategoryDto> Handle(IntId Id)
        {
            var contactNumberCategory = await _contactNumberCategoryQueryService.Get(Id.Id);
            return _mapper.Map<GetContactNumberCategoryDto>(contactNumberCategory);
        }
    }
}
