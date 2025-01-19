using AutoMapper;
using SmsHub.Application.Features.Security.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.Entities;
using SmsHub.Persistence.Features.Security.Commands.Contracts;

namespace SmsHub.Application.Features.Security.Handlers.Commands.Create.Implementations
{
    public class UserLineCreateHandler : IUserLineCreateHandler
    {
        private readonly IUserLineCommandService _userLineCommandService;
        private readonly IMapper _mapper;
        public UserLineCreateHandler(
            IUserLineCommandService userLineCommandService,
            IMapper mapper)
        {
            _userLineCommandService = userLineCommandService;
            _userLineCommandService.NotNull(nameof(userLineCommandService));

            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));
        }
        public async Task Handle(CreateUserLineDto createUserLineDto,CancellationToken cancellationToken)
        {
            var userLine = _mapper.Map<UserLine>(createUserLineDto);
            await _userLineCommandService.Add(userLine);
        }
    }
}
