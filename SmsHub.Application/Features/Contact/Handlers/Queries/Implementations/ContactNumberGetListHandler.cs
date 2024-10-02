using AutoMapper;
using SmsHub.Application.Features.Contact.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;

namespace SmsHub.Application.Features.Contact.Handlers.Queries.Implementations
{
    public class ContactNumberGetListHandler: IContactNumberGetListHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactNumberQueryService _contactNumberQueryService;
        public ContactNumberGetListHandler(IMapper mapper, IContactNumberQueryService contactNumberQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _contactNumberQueryService = contactNumberQueryService;
            _contactNumberQueryService.NotNull(nameof(contactNumberQueryService));
        }
        public async Task<ICollection<GetContactNumberDto>> Handle()
        {
            var contactNumbers = await _contactNumberQueryService.Get();
            return _mapper.Map<ICollection<GetContactNumberDto>>(contactNumbers);
        }
    }
}
