using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Contact.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;
using System.Threading;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Delete.Implementations
{
    public class ContactDeleteHandler : IContactDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactCommandService _contactCommandService;
        private readonly IContactQueryService _contactQueryService;
        private readonly IValidator<DeleteContactDto> _validator;

        public ContactDeleteHandler(
            IMapper mapper,
            IContactCommandService contactCommandService,
            IContactQueryService contactQueryService,
            IValidator<DeleteContactDto> validator)
        {
            _mapper = mapper;
            _contactCommandService = contactCommandService;
            _contactQueryService = contactQueryService;

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }
        public async Task Handle(DeleteContactDto deleteContactDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(deleteContactDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var contact = await _contactQueryService.Get(deleteContactDto.Id);
            _contactCommandService.Delete(contact);
        }
    }
}
