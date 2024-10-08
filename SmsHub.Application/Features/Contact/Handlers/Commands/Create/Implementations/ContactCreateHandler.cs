using AutoMapper;
using MediatR;
using SmsHub.Application.Features.Contact.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Create.Implementations
{
    public class ContactCreateHandler : IContactCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactCommandService _contactCommandService;
        public ContactCreateHandler(IMapper mapper, IContactCommandService contactCommandService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _contactCommandService = contactCommandService;
            _contactCommandService.NotNull(nameof(_contactCommandService));
        }

        public async Task Handle(CreateContactDto request, CancellationToken cancellationToken)
        {
            var contact = _mapper.Map<Entities.Contact>(request);
            await _contactCommandService.Add(contact);
        }
    }
}
