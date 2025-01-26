using AutoMapper;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Contact.Handlers.Commands.Create.Contracts;
using FluentValidation;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Create.Implementations
{
    public class ContactCategoryCreateHandler : IContactCategoryCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactCategoryCommandService _contactCategoryCommandService;
        private readonly IValidator<CreateContactCategoryDto> _validator;
        public ContactCategoryCreateHandler(
            IMapper mapper, 
            IContactCategoryCommandService contactCategoryCommandService, 
            IValidator<CreateContactCategoryDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _contactCategoryCommandService = contactCategoryCommandService;
            _contactCategoryCommandService.NotNull(nameof(_contactCategoryCommandService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }

        public async Task Handle(CreateContactCategoryDto createContactCategoryDto, CancellationToken cancellationToken)
        {
            await CheckValidator(createContactCategoryDto, cancellationToken);

            var contactCategory = _mapper.Map<Entities.ContactCategory>(createContactCategoryDto);
            await _contactCategoryCommandService.Add(contactCategory);
        }
        private async Task CheckValidator(CreateContactCategoryDto createContactCategoryDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(createContactCategoryDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }
        }

    }
}
