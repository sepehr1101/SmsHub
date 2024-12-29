using AutoMapper;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Line.Commands.Contracts;
using SmsHub.Application.Features.Line.Handlers.Commands.Create.Contracts;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using FluentValidation;
using Newtonsoft.Json;
using MagfaCredentialDto = SmsHub.Domain.Providers.Magfa3000.Entities.Responses.CredentialDto;
using KavenegarCredentialDto = SmsHub.Domain.Providers.Kavenegar.Entities.Responses.CredentialDto;
using SmsHub.Domain.Constants;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Common.Services.Implementations;
using SmsHub.Application.Features.Line.Validations;

namespace SmsHub.Application.Features.Line.Handlers.Commands.Create.Implementations
{
    public class LineCreateHandler : ILineCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly ILineCommandService _lineCommandService;
        private readonly IValidator<CreateLineDto> _validator;
        public LineCreateHandler(
            IMapper mapper,
            ILineCommandService lineCommandService,
            IValidator<CreateLineDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _lineCommandService = lineCommandService;
            _lineCommandService.NotNull(nameof(_lineCommandService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }

        public async Task Handle(CreateLineDto request, CancellationToken cancellationToken)
        {
            LineCredentialValidation.ValidationCreateLine(request);//todo: I move ValidationProvider  To LineCredentialValidation , true or not?

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException("خطا در اطلاعات ورودی");
            }

            var line = _mapper.Map<Entities.Line>(request);
            await _lineCommandService.Add(line);
        }

    }
}
