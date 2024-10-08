﻿using FluentValidation;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
namespace SmsHub.Application.Features.Config.Validations
{
    internal class ConfigTypeGroupUpdateValidation : AbstractValidator<UpdateConfigTypeGroupDto>
    {
        public ConfigTypeGroupUpdateValidation()
        {
            RuleFor(x => x.Title).NotEmpty().Length(3, 255);
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
