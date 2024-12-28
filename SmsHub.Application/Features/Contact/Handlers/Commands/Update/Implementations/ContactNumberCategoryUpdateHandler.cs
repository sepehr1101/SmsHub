using AutoMapper;
using FluentValidation;
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
        private readonly IValidator<UpdateContactNumberCategoryDto> _validator;
        public ContactNumberCategoryUpdateHandler(
            IMapper mapper, 
            IContactNumberCategoryQueryService contactNumberCategoryQueryService,
            IValidator<UpdateContactNumberCategoryDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _contactNumberCategoryQueryService = contactNumberCategoryQueryService;
            _contactNumberCategoryQueryService.NotNull(nameof(contactNumberCategoryQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(UpdateContactNumberCategoryDto updateContactNumberCategoryDto, CancellationToken cancellationToken)
        {
            var validationResult=await _validator.ValidateAsync(updateContactNumberCategoryDto, cancellationToken); 
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var contactNumberCategory = await _contactNumberCategoryQueryService.Get(updateContactNumberCategoryDto.Id);
            _mapper.Map(updateContactNumberCategoryDto, contactNumberCategory);
        }
    }
}
