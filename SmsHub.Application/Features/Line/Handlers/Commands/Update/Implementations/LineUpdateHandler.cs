using AutoMapper;
using Azure.Core;
using FluentValidation;
using MediatR;
using SmsHub.Application.Features.Line.Handlers.Commands.Update.Contracts;
using SmsHub.Application.Features.Line.Validations;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Features.Line.Queries.Contracts;

namespace SmsHub.Application.Features.Line.Handlers.Commands.Update.Implementations
{
    public class LineUpdateHandler : ILineUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly ILineQueryService _lineQueryService;
        private readonly IValidator<UpdateLineDto> _validator;
        public LineUpdateHandler(
            IMapper mapper,
            ILineQueryService lineQueryService,
            IValidator<UpdateLineDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _lineQueryService = lineQueryService;
            _lineQueryService.NotNull(nameof(lineQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(UpdateLineDto updateLineDto, CancellationToken cancellationToken)
        {
            LineCredentialValidation.ValidationUpdateLine(updateLineDto);

            var validationResult = await _validator.ValidateAsync(updateLineDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var line = await _lineQueryService.Get(updateLineDto.Id);
            _mapper.Map(updateLineDto, line);
        }
    }
}
