using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Create
{
    public class CreateContactNumberCommandHandler : IRequestHandler<CreateContactNumberDto>
    {
        private readonly IMapper _mapper;
        private readonly IContactNumberCommandService _contactNumberCommandService;

        public CreateContactNumberCommandHandler(IMapper mapper,IContactNumberCommandService contactNumberCommandService)
        {
            _mapper=mapper;
            _mapper.NotNull(nameof(_mapper));

            _contactNumberCommandService=contactNumberCommandService;
            _contactNumberCommandService.NotNull(nameof(_contactNumberCommandService));
        }

        public async Task Handle(CreateContactNumberDto request, CancellationToken cancellationToken)
        {
            var contactNumber = _mapper.Map<Entities.ContactNumber>(request);
            await _contactNumberCommandService.Add(contactNumber);
        }
    }
}
