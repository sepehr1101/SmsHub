using AutoMapper;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Common.Extensions;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Contact.Handlers.Commands.Create.Contracts;
using FluentValidation;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Create.Implementations
{
    public class ContactNumberCreateHandler : IContactNumberCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactNumberCommandService _contactNumberCommandService;
        private readonly IValidator<CreateContactNumberDto> _validator;

        public ContactNumberCreateHandler(
            IMapper mapper,
            IContactNumberCommandService contactNumberCommandService, 
            IValidator<CreateContactNumberDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _contactNumberCommandService = contactNumberCommandService;
            _contactNumberCommandService.NotNull(nameof(_contactNumberCommandService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }

        public async Task Handle(CreateContactNumberDto request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var contactNumber = _mapper.Map<Entities.ContactNumber>(request);
            await _contactNumberCommandService.Add(contactNumber);
        }
    }
}
