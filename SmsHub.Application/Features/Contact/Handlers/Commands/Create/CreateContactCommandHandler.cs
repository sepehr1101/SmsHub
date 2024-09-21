using AutoMapper;
using MediatR;
using SmsHub.Common;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Create
{
    public class CreateContactCommandHandler:IRequestHandler<CreateContactDto>
    {
        private readonly IMapper _mapper;
        private readonly IContactCommandService _contactCommandService;
        public CreateContactCommandHandler(IMapper mapper, IContactCommandService contactCommandService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _contactCommandService = contactCommandService; 
            _contactCommandService.NotNull(nameof(_contactCommandService));
        }

        public async Task Handle(CreateContactDto request, CancellationToken cancellationToken)
        {
            var contact=_mapper.Map<Entities.Contact>(request);
            await _contactCommandService.Add(contact);
        }
    }
}
