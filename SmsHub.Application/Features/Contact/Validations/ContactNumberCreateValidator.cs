﻿using FluentValidation;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Contact.Validations
{
    internal class ContactNumberCreateValidator:AbstractValidator<CreateContactNumberDto>
    {
        public ContactNumberCreateValidator()
        {
            RuleFor(x => x.Number).NotEmpty().MaximumLength(255);
        }
    }
}
