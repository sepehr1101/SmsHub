using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Contact.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Delete.Implementations
{
    public class ContactNumberDeleteHandler: IContactNumberDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactNumberCommandService _contactNumberCommandService;
        private readonly IContactNumberQueryService _contactNumberQueryService;
        private readonly IValidator<DeleteContactNumberDto> _validator;
        public ContactNumberDeleteHandler(
            IMapper mapper, 
            IContactNumberCommandService contactNumberCommandService, 
            IContactNumberQueryService contactNumberQueryService,
            IValidator<DeleteContactNumberDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _contactNumberCommandService = contactNumberCommandService;
            _contactNumberCommandService.NotNull(nameof(contactNumberQueryService));

            _contactNumberQueryService = contactNumberQueryService;
            _contactNumberQueryService.NotNull(nameof(contactNumberQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(DeleteContactNumberDto deleteContactNumberDto, CancellationToken cancellationToken)
        {
            var validationResult=await _validator.ValidateAsync(deleteContactNumberDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var contactNumber = await _contactNumberQueryService.Get(deleteContactNumberDto.Id);
            _contactNumberCommandService.Delete(contactNumber);
        }
    }
}
