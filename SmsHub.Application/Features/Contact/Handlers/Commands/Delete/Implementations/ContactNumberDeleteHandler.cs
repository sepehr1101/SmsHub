using AutoMapper;
using SmsHub.Application.Features.Contact.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Delete.Implementations
{
    public class ContactNumberDeleteHandler: IContactNumberDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactNumberCommandService _contactNumberCommandService;
        private readonly IContactNumberQueryService _contactNumberQueryService;
        public ContactNumberDeleteHandler(
            IMapper mapper, 
            IContactNumberCommandService contactNumberCommandService, 
            IContactNumberQueryService contactNumberQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _contactNumberCommandService = contactNumberCommandService;
            _contactNumberCommandService.NotNull(nameof(contactNumberQueryService));

            _contactNumberQueryService = contactNumberQueryService;
            _contactNumberQueryService.NotNull(nameof(contactNumberQueryService));
        }
        public async Task Handle(DeleteContactNumberDto deleteContactNumberDto, CancellationToken cancellationToken)
        {
            var contactNumber = await _contactNumberQueryService.Get(deleteContactNumberDto.Id);
            _contactNumberCommandService.Delete(contactNumber);
        }
    }
}
