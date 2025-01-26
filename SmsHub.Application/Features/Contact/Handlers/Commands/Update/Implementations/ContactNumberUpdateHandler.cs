using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Contact.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Update.Implementations
{
    public class ContactNumberUpdateHandler : IContactNumberUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactNumberQueryService _contactNumberQueryService;
        private readonly IValidator<UpdateContactNumberDto> _validator;
        public ContactNumberUpdateHandler(
            IMapper mapper, 
            IContactNumberQueryService contactNumberQueryService, 
            IValidator<UpdateContactNumberDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _contactNumberQueryService = contactNumberQueryService;
            _contactNumberQueryService.NotNull(nameof(contactNumberQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(UpdateContactNumberDto updateContactNumberDto, CancellationToken cancellationToken)
        {
            await CheckValidator(updateContactNumberDto, cancellationToken);

            var contactNumber = await _contactNumberQueryService.Get(updateContactNumberDto.Id);
            _mapper.Map(updateContactNumberDto, contactNumber);
        }
        private async Task CheckValidator(UpdateContactNumberDto updateContactNumberDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateContactNumberDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }
        }

    }
}
