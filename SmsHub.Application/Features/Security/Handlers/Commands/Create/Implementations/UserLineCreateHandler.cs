using AutoMapper;
using SmsHub.Application.Features.Security.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.Entities;
using SmsHub.Persistence.Features.Line.Queries.Contracts;
using SmsHub.Persistence.Features.Security.Commands.Contracts;
using SmsHub.Persistence.Features.Security.Queries.Contracts;

namespace SmsHub.Application.Features.Security.Handlers.Commands.Create.Implementations
{
    public class UserLineCreateHandler : IUserLineCreateHandler
    {
        private readonly IUserLineCommandService _userLineCommandService;
        private readonly IMapper _mapper;
        private readonly IUserQueryService _userQueryService;
        private readonly ILineQueryService _lineQueryService;
        public UserLineCreateHandler(
            IUserLineCommandService userLineCommandService,
            IMapper mapper,
            IUserQueryService userQueryService,
            ILineQueryService lineQueryService)
        {
            _userLineCommandService = userLineCommandService;
            _userLineCommandService.NotNull(nameof(userLineCommandService));

            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _userQueryService = userQueryService;
            _userQueryService.NotNull(nameof(userQueryService));

            _lineQueryService = lineQueryService; 
            _lineQueryService.NotNull(nameof(lineQueryService));    
        }
        public async Task Handle(CreateUserLineDto createUserLineDto,CancellationToken cancellationToken)
        {
            var user=await _userQueryService.Get(createUserLineDto.UserId);
            var line=await _lineQueryService.Get(createUserLineDto.LineId);

            var userLine = _mapper.Map<UserLine>(createUserLineDto);
            await _userLineCommandService.Add(userLine);
        }
    }
}
