﻿using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Contact.Handlers.Commands.Create.Contracts;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Create.Implementations
{
    public class ContactCategoryCreateHandler : IContactCategoryCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactCategoryCommandService _contactCategoryCommandService;
        public ContactCategoryCreateHandler(IMapper mapper, IContactCategoryCommandService contactCategoryCommandService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _contactCategoryCommandService = contactCategoryCommandService;
            _contactCategoryCommandService.NotNull(nameof(_contactCategoryCommandService));
        }

        public async Task Handle(CreateContactCategoryDto request, CancellationToken cancellationToken)
        {
            var contactCategory = _mapper.Map<Entities.ContactCategory>(request);
            await _contactCategoryCommandService.Add(contactCategory);
        }
    }
}
