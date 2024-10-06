using AutoMapper;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;

namespace SmsHub.Application.Features.Contact.Handlers.Queries.Implementations
{
    public class ContactGetListHandler: IContactGetListHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactQueryService _contactQueryService;
        public ContactGetListHandler(IMapper mapper, IContactQueryService contactQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _contactQueryService = contactQueryService;
            _contactQueryService.NotNull(nameof(contactQueryService));
        }
        public async Task<ICollection<GetContactDto>> Handle()
        {
            var contacts = await _contactQueryService.Get();
            return _mapper.Map<ICollection<GetContactDto>>(contacts);
        }
    }
}
