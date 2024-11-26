using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Contact.Handlers.Commands.Create.Contracts;
using FluentValidation;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;
using System.Threading;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Create.Implementations
{
    public class ContactCategoryCreateHandler : IContactCategoryCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactCategoryCommandService _contactCategoryCommandService;
        private readonly IValidator<CreateContactCategoryDto> _validator;
        public ContactCategoryCreateHandler(IMapper mapper, IContactCategoryCommandService contactCategoryCommandService, IValidator<CreateContactCategoryDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _contactCategoryCommandService = contactCategoryCommandService;
            _contactCategoryCommandService.NotNull(nameof(_contactCategoryCommandService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }

        public async Task Handle(CreateContactCategoryDto request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var contactCategory = _mapper.Map<Entities.ContactCategory>(request);
            await _contactCategoryCommandService.Add(contactCategory);
        }
    }
}
