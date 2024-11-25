using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Line.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Line.Commands.Contracts;
using SmsHub.Persistence.Features.Line.Queries.Contracts;

namespace SmsHub.Application.Features.Line.Handlers.Commands.Delete.Implementations
{
    public class LineDeleteHandler : ILineDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly ILineCommandService _lineCommandService;
        private readonly ILineQueryService _lineQueryService;
        private readonly IValidator<DeleteLineDto> _validator;
        public LineDeleteHandler(
            IMapper mapper,
            ILineCommandService lineCommandService,
            ILineQueryService lineQueryService,
            IValidator<DeleteLineDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _lineCommandService = lineCommandService;
            _lineCommandService.NotNull(nameof(lineCommandService));

            _lineQueryService = lineQueryService;
            _lineQueryService.NotNull(nameof(lineQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(DeleteLineDto deleteLineDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(deleteLineDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var line = await _lineQueryService.Get(deleteLineDto.Id);
            _lineCommandService.Delete(line);
        }
    }
}
