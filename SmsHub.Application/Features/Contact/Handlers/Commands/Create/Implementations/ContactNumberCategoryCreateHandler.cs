using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Contact.Handlers.Commands.Create.Contracts;
using Azure.Core;
using FluentValidation;
using System.Threading;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Create.Implementations
{
    public class ContactNumberCategoryCreateHandler : IContactNumberCategoryCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactNumberCategoryCommandService _contactNumberCategoryCommandService;
        private readonly IValidator<CreateContactNumberCategoryDto> _validator;
        public ContactNumberCategoryCreateHandler(IMapper mapper, IContactNumberCategoryCommandService contactNumberCategoryCommandService, IValidator<CreateContactNumberCategoryDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _contactNumberCategoryCommandService = contactNumberCategoryCommandService;
            _contactNumberCategoryCommandService.NotNull(nameof(_contactNumberCategoryCommandService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }

        public async Task Handle(CreateContactNumberCategoryDto request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var contactNumberCategory = _mapper.Map<Entities.ContactNumberCategory>(request);
            await _contactNumberCategoryCommandService.Add(contactNumberCategory);
        }
    }
}
