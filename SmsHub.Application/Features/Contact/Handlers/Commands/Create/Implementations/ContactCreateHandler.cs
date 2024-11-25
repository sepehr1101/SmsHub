using AutoMapper;
using Azure.Core;
using FluentValidation;
using MediatR;
using SmsHub.Application.Features.Contact.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;
using System.Threading;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Create.Implementations
{
    public class ContactCreateHandler : IContactCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactCommandService _contactCommandService;
        private readonly IValidator<CreateContactDto> _validator;
        public ContactCreateHandler(IMapper mapper, IContactCommandService contactCommandService, IValidator<CreateContactDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _contactCommandService = contactCommandService;
            _contactCommandService.NotNull(nameof(_contactCommandService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }

        public async Task Handle(CreateContactDto request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var contact = _mapper.Map<Entities.Contact>(request);
            await _contactCommandService.Add(contact);
        }
    }
}
