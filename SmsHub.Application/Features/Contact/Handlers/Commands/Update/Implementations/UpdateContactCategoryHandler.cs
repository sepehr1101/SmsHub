using AutoMapper;
using SmsHub.Application.Features.Contact.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Update.Implementations
{
    public class UpdateContactCategoryHandler: IUpdateContactCategoryHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactCategoryQueryService _contactCategoryQueryService;
        public UpdateContactCategoryHandler(IMapper mapper, IContactCategoryQueryService contactCategoryQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _contactCategoryQueryService = contactCategoryQueryService;
            _contactCategoryQueryService.NotNull(nameof(contactCategoryQueryService));
        }
        public async Task Handle(UpdateContactCategoryDto updateContactCategoryDto, CancellationToken cancellationToken)
        {
            var contactCategory = await _contactCategoryQueryService.Get(updateContactCategoryDto.Id);
            _mapper.Map(updateContactCategoryDto, contactCategory);
        }
    }
}
