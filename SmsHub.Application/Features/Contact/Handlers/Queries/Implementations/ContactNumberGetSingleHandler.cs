using AutoMapper;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;

namespace SmsHub.Application.Features.Contact.Handlers.Queries.Implementations
{
    public class ContactNumberGetSingleHandler: IContactNumberGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactNumberQueryService _contactNumberQueryService;
        public ContactNumberGetSingleHandler(IMapper mapper, IContactNumberQueryService contactNumberQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _contactNumberQueryService = contactNumberQueryService;
            _contactNumberQueryService.NotNull(nameof(contactNumberQueryService));
        }
        public async Task<GetContactNumberDto> Handle(IntId Id)
        {
            var contactNumber = await _contactNumberQueryService.Get(Id.Id);
            return _mapper.Map<GetContactNumberDto>(contactNumber);
        }
    }
}
