using AutoMapper;
using FluentValidation;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Security.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Features.Line.Queries.Contracts;
using SmsHub.Persistence.Features.Line.Queries.Implementations;
using SmsHub.Persistence.Features.Security.Commands.Contracts;
using SmsHub.Persistence.Features.Security.Queries.Contracts;
using SmsHub.Persistence.Features.Security.Queries.Implementations;

namespace SmsHub.Application.Features.Security.Handlers.Commands.Update.Implementations
{
    public class UserLineUpdateHandler : IUserLineUpdateHandler
    {
        private readonly IUserLineCommandService _userLineCommandService;
        private readonly IUserLineQueryService _userLineQueryService;
        private readonly IMapper _mapper;
        private readonly IUserQueryService _userQueryService;
        private readonly ILineQueryService _lineQueryService;
        public UserLineUpdateHandler(
            IUserLineCommandService userLineCommandService,
            IUserLineQueryService userLineQueryService,
            IMapper mapper,
            IUserQueryService userQueryService,
            ILineQueryService lineQueryService)
        {
            _userLineCommandService = userLineCommandService;
            _userLineCommandService.NotNull(nameof(userLineCommandService));

            _userLineQueryService = userLineQueryService;
            _userLineQueryService.NotNull(nameof(userLineQueryService));

            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _userQueryService = userQueryService;
            _userQueryService.NotNull(nameof(userQueryService));

            _lineQueryService = lineQueryService;
            _lineQueryService.NotNull(nameof(lineQueryService));

        }

        public async Task Handle(UpdateUserLineDto updateUserLineDto, CancellationToken cancellationToken)
        {
            var userLine = await _userLineQueryService.GetById(updateUserLineDto.Id);
            if (userLine == null)
            {
                throw new InvalidForeignKeyException(nameof(userLine));
            }
            var user = await _userQueryService.Get(updateUserLineDto.UserId);
            var line = await _lineQueryService.Get(updateUserLineDto.LineId);

            var x = _mapper.Map(updateUserLineDto, userLine);
        }

    }
}
