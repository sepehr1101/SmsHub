using FluentValidation;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Application.Features.Line.Validations
{
    public class LineUpdateValidator:AbstractValidator<UpdateLineDto>
    {
    }
}
