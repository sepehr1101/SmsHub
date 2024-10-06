using AutoMapper;
using SmsHub.Application.Features.Contact.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Update.Implementations
{
    public class UpdateContactHandler : IUpdateContactHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactQueryService _contactQueryService;
        public UpdateContactHandler(IMapper mapper, IContactQueryService contactQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _contactQueryService = contactQueryService;
            _contactQueryService.NotNull(nameof(contactQueryService));
        }
        public async Task Handle(UpdateContactDto updateContactDto, CancellationToken cancellationToken)
        {
            var contact = await _contactQueryService.Get(updateContactDto.Id);
            _mapper.Map(updateContactDto, contact);
        }

    }
}
