﻿using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Contact.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Contact.Queries.Contracts;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Update.Implementations
{
    public class ContactCategoryUpdateHandler: IContactCategoryUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactCategoryQueryService _contactCategoryQueryService;
        private readonly IValidator<UpdateContactCategoryDto> _validator;
        public ContactCategoryUpdateHandler(
            IMapper mapper, 
            IContactCategoryQueryService contactCategoryQueryService,
            IValidator<UpdateContactCategoryDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _contactCategoryQueryService = contactCategoryQueryService;
            _contactCategoryQueryService.NotNull(nameof(contactCategoryQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(UpdateContactCategoryDto updateContactCategoryDto, CancellationToken cancellationToken)
        {
            var validationResult=await _validator.ValidateAsync(updateContactCategoryDto, cancellationToken);   
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var contactCategory = await _contactCategoryQueryService.Get(updateContactCategoryDto.Id);
            _mapper.Map(updateContactCategoryDto, contactCategory);
        }
    }
}
