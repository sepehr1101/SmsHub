﻿using FluentValidation;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Sending.Validations
{
    internal class MessageHolderCreateValidator : AbstractValidator<CreateMessagesHolderDto>
    {
    }
}