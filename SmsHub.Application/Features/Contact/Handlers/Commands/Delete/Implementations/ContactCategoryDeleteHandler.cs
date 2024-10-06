using AutoMapper;
using SmsHub.Application.Features.Contact.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Delete.Implementations
{
    public class ContactCategoryDeleteHandler: IContactCategoryDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactCategoryCommandService _contactCategoryCommandService;
        private readonly IContactCategoryQueryService _contactCategoryQueryService;
        public ContactCategoryDeleteHandler( 
            IMapper mapper,
            IContactCategoryCommandService contactCategoryCommandService,
            IContactCategoryQueryService contactCategoryQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _contactCategoryCommandService = contactCategoryCommandService;
            _contactCategoryCommandService.NotNull(nameof(contactCategoryQueryService));

            _contactCategoryQueryService = contactCategoryQueryService;
            _contactCategoryQueryService.NotNull(nameof(contactCategoryQueryService));
        }
        public async Task Handle(DeleteContactCategoryDto deleteContactCategoryDto, CancellationToken cancellationToken)
        {
            var contactCategory = await _contactCategoryQueryService.Get(deleteContactCategoryDto.Id);
            _contactCategoryCommandService.Delete(contactCategory);
        }
    }
}
