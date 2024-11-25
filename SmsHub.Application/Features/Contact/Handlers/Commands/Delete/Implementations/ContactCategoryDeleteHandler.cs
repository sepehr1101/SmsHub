using AutoMapper;
using Azure.Core;
using FluentValidation;
using SmsHub.Application.Features.Contact.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;
using System.Threading;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Delete.Implementations
{
    public class ContactCategoryDeleteHandler : IContactCategoryDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactCategoryCommandService _contactCategoryCommandService;
        private readonly IContactCategoryQueryService _contactCategoryQueryService;
        private readonly IValidator<DeleteContactCategoryDto> _validator;

        public ContactCategoryDeleteHandler(
            IMapper mapper,
            IContactCategoryCommandService contactCategoryCommandService,
            IContactCategoryQueryService contactCategoryQueryService,
            IValidator<DeleteContactCategoryDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _contactCategoryCommandService = contactCategoryCommandService;
            _contactCategoryCommandService.NotNull(nameof(contactCategoryQueryService));

            _contactCategoryQueryService = contactCategoryQueryService;
            _contactCategoryQueryService.NotNull(nameof(contactCategoryQueryService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }
        public async Task Handle(DeleteContactCategoryDto deleteContactCategoryDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(deleteContactCategoryDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var contactCategory = await _contactCategoryQueryService.Get(deleteContactCategoryDto.Id);
            _contactCategoryCommandService.Delete(contactCategory);
        }
    }
}
