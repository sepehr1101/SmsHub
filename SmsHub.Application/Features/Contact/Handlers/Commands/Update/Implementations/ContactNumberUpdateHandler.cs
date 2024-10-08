﻿using AutoMapper;
using SmsHub.Application.Features.Contact.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Update.Implementations
{
    public class ContactNumberUpdateHandler: IContactNumberUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactNumberQueryService _contactNumberQueryService;
        public ContactNumberUpdateHandler(IMapper mapper, IContactNumberQueryService contactNumberQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _contactNumberQueryService = contactNumberQueryService;
            _contactNumberQueryService.NotNull(nameof(contactNumberQueryService));
        }
        public async Task Handle(UpdateContactNumberDto updateContactNumberDto, CancellationToken cancellationToken)
        {
            var contactNumber = await _contactNumberQueryService.Get(updateContactNumberDto.Id);
            _mapper.Map(updateContactNumberDto, contactNumber);
        }
    }
}
