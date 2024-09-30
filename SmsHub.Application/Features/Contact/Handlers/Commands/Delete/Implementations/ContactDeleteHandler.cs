using AutoMapper;
using SmsHub.Application.Features.Contact.Handlers.Commands.Delete.Contracts;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Delete.Implementations
{
    public class ContactDeleteHandler: IContactDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactCommandService _contactCommandService;
        private readonly IContactQueryService _contactQueryService;
        public ContactDeleteHandler(
            IMapper mapper, 
            IContactCommandService contactCommandService, 
            IContactQueryService contactQueryService)
        {
            _mapper = mapper;
            _contactCommandService = contactCommandService;
            _contactQueryService = contactQueryService;
        }
        public async Task Handle(DeleteContactDto deleteContactDto, CancellationToken cancellationToken)
        {
            var contact=await _contactQueryService.Get(deleteContactDto.Id);
            _contactCommandService.Delete(contact);
        }
    }
}
