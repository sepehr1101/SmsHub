﻿using FluentValidation;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Consumer.Validations
{
    public class ConsumerSafaIpCreateValidator : AbstractValidator<CreateConsumerSafeIpDto>
    {
        public ConsumerSafaIpCreateValidator()
        {
            RuleFor(x => x.FromIp)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .MaximumLength(64).WithMessage(MessageResources.ItemNotMoreThan64);

            RuleFor(x => x.ToIp)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .MaximumLength(64).WithMessage(MessageResources.ItemNotMoreThan64);
        }
    }
}
