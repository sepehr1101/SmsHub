using AutoMapper;
using FluentValidation;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Contact.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Create.Implementations
{
    public class ContactCreateHandler : IContactCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactCommandService _contactCommandService;
        private readonly IValidator<CreateContactDto> _validator;
        public ContactCreateHandler(
            IMapper mapper, 
            IContactCommandService contactCommandService, 
            IValidator<CreateContactDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _contactCommandService = contactCommandService;
            _contactCommandService.NotNull(nameof(_contactCommandService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }

        public async Task Handle(CreateContactDto createContactDto, CancellationToken cancellationToken)
        {
            await CheckValidator(createContactDto, cancellationToken);

            var contact = _mapper.Map<Entities.Contact>(createContactDto);
            await _contactCommandService.Add(contact);
        }
        private async Task CheckValidator(CreateContactDto createContactDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(createContactDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new FluentValidationException(message);
            }
        }

    }
}
