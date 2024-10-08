﻿using FluentValidation;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Consumer.Validations
{
    internal class ConsumerSafaIpUpdateValidator:AbstractValidator<UpdateConsumerSafeIpDto>
    {
        public ConsumerSafaIpUpdateValidator()
        {
            RuleFor(x => x.FromIp).NotEmpty().MaximumLength(64);
            RuleFor(x => x.ToIp).NotEmpty().MaximumLength(64);
        }
    }
}
