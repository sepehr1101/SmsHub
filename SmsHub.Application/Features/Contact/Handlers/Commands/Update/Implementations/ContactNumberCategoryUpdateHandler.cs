using AutoMapper;
using SmsHub.Application.Features.Contact.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Update.Implementations
{
    public  class ContactNumberCategoryUpdateHandler: IContactNumberCategoryUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactNumberCategoryQueryService _contactNumberCategoryQueryService;
        public ContactNumberCategoryUpdateHandler(IMapper mapper, IContactNumberCategoryQueryService contactNumberCategoryQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _contactNumberCategoryQueryService = contactNumberCategoryQueryService;
            _contactNumberCategoryQueryService.NotNull(nameof(contactNumberCategoryQueryService));
        }
        public async Task Handle(UpdateContactNumberCategoryDto updateContactNumberCategoryDto, CancellationToken cancellationToken)
        {
            var contactNumberCategory = await _contactNumberCategoryQueryService.Get(updateContactNumberCategoryDto.Id);
            _mapper.Map(updateContactNumberCategoryDto, contactNumberCategory);
        }
    }
}
