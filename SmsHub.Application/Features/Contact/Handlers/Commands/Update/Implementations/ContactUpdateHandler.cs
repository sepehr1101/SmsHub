using AutoMapper;
using FluentValidation;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Contact.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Update.Implementations
{
    public class ContactUpdateHandler : IContactUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactQueryService _contactQueryService;
        private readonly IValidator<UpdateContactDto> _validator;
        public ContactUpdateHandler(
            IMapper mapper, 
            IContactQueryService contactQueryService, 
            IValidator<UpdateContactDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _contactQueryService = contactQueryService;
            _contactQueryService.NotNull(nameof(contactQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(UpdateContactDto updateContactDto, CancellationToken cancellationToken)
        {
            await CheckValidator(updateContactDto, cancellationToken);


            var contact = await _contactQueryService.Get(updateContactDto.Id);
            _mapper.Map(updateContactDto, contact);
        }
        private async Task CheckValidator(UpdateContactDto updateContactDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateContactDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new FluentValidationException(message);
            }
        }

    }
}
