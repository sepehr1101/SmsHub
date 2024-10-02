using AutoMapper;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;

namespace SmsHub.Application.Features.Contact.Handlers.Queries.Implementations
{
    public class ContactGetSingleHandler: IContactGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactQueryService _contactQueryService;
        public ContactGetSingleHandler(IMapper mapper, IContactQueryService contactQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _contactQueryService = contactQueryService;
            _contactQueryService.NotNull(nameof(contactQueryService));
        }
        public async Task<GetContactDto> Handle(int Id)
        {
            var contact = await _contactQueryService.Get(Id);
            return _mapper.Map<GetContactDto>(contact);
        }
    }
}
