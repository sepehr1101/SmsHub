using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Contact.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Delete.Implementations
{
    public class ContactNumberCategoryDeleteHandler : IContactNumberCategoryDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactNumberCategoryCommandService _contactNumberCategoryCommandService;
        private readonly IContactNumberCategoryQueryService _contactNumberCategoryQueryService;
        private readonly IValidator<DeleteContactNumberCategoryDto> _validator;
        public ContactNumberCategoryDeleteHandler(
            IMapper mapper,
            IContactNumberCategoryCommandService contactNumberCategoryCommandService,
            IContactNumberCategoryQueryService contactNumberCategoryQueryService,
            IValidator<DeleteContactNumberCategoryDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _contactNumberCategoryCommandService = contactNumberCategoryCommandService;
            _contactNumberCategoryCommandService.NotNull(nameof(contactNumberCategoryQueryService));

            _contactNumberCategoryQueryService = contactNumberCategoryQueryService;
            _contactNumberCategoryQueryService.NotNull(nameof(contactNumberCategoryQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(DeleteContactNumberCategoryDto deleteContactNumberCategoryDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(deleteContactNumberCategoryDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var contactNumberCategory = await _contactNumberCategoryQueryService.Get(deleteContactNumberCategoryDto.Id);
            _contactNumberCategoryCommandService.Delete(contactNumberCategory);
        }
    }
}
