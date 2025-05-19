using AutoMapper;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Line.Commands.Contracts;
using SmsHub.Application.Features.Line.Handlers.Commands.Create.Contracts;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using FluentValidation;
using SmsHub.Application.Features.Line.Validations;
using SmsHub.Application.Exceptions;

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

        public async Task Handle(CreateLineDto createLineDto, CancellationToken cancellationToken)
        {
            LineCredentialValidation.ValidationCreateLine(createLineDto);

            await CheckValidator(createLineDto, cancellationToken);

            var line = _mapper.Map<Entities.Line>(createLineDto);
            await _lineCommandService.Add(line);
        }

        private async Task CheckValidator(CreateLineDto createLineDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(createLineDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new FluentValidationException(message);
            }
        }

    }
}
