using AutoMapper;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Contact.Handlers.Commands.Create.Contracts;
using FluentValidation;
using SmsHub.Application.Exceptions;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Create.Implementations
{
    public class ContactNumberCategoryCreateHandler : IContactNumberCategoryCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactNumberCategoryCommandService _contactNumberCategoryCommandService;
        private readonly IValidator<CreateContactNumberCategoryDto> _validator;
        public ContactNumberCategoryCreateHandler(
            IMapper mapper,
            IContactNumberCategoryCommandService contactNumberCategoryCommandService, 
            IValidator<CreateContactNumberCategoryDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _contactNumberCategoryCommandService = contactNumberCategoryCommandService;
            _contactNumberCategoryCommandService.NotNull(nameof(_contactNumberCategoryCommandService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }

        public async Task Handle(CreateContactNumberCategoryDto createContactNumberCategoryDto, CancellationToken cancellationToken)
        {
            await CheckValidator(createContactNumberCategoryDto, cancellationToken);

            var contactNumberCategory = _mapper.Map<Entities.ContactNumberCategory>(createContactNumberCategoryDto);
            await _contactNumberCategoryCommandService.Add(contactNumberCategory);
        }
        private async Task CheckValidator(CreateContactNumberCategoryDto createContactNumberCategoryDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(createContactNumberCategoryDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new FluentValidationException(message);
            }
        }


    }
}
