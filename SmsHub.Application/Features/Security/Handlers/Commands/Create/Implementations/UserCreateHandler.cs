using SmsHub.Application.Features.Auth.Handlers.Commands.Create.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Features.Security.Commands.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.Entities;

namespace SmsHub.Application.Features.Auth.Handlers.Commands.Create.Implementations
{
    public class UserCreateHandler : IUserCreateHandler
    {
        private readonly IUserCommandService _userCommandService;
        private readonly IUserRoleCommandService _userRoleCommandService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        public UserCreateHandler(
            IUserCommandService userCommandService,
            IUserRoleCommandService userRoleCommandService,
            IMapper mapper,
            IHttpContextAccessor contextAccessor)
        {
            _userCommandService = userCommandService;
            _userCommandService.NotNull(nameof(userCommandService));

            _userRoleCommandService = userRoleCommandService;
            _userRoleCommandService.NotNull(nameof(userRoleCommandService));

            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _contextAccessor = contextAccessor;
            _contextAccessor.NotNull(nameof(contextAccessor));
        }
        public async Task Handle(UserCreateDto userCreateDto, CancellationToken cancellationToken)
        {
            var logInfo = DeviceDetection.GetLogInfo(_contextAccessor.HttpContext.Request);
            var logInfoString = JsonOperation.Marshal(logInfo);
            Guid operationGroupId = Guid.NewGuid();
            var userRoles = CreateUserRoles(userCreateDto.RoleIds, logInfoString, operationGroupId, operationGroupId);

            var user = _mapper.Map<User>(userCreateDto);
            user.Id = operationGroupId;
            user.InsertLogInfo = logInfoString;
            user.ValidFrom = DateTime.Now;
            user.ValidTo = null;
            user.Password = await SecurityOperations.GetSha512Hash(userCreateDto.Password);
            user.SerialNumber = Guid.NewGuid().ToString("N");

            await _userCommandService.Add(user);
            await _userRoleCommandService.Add(userRoles);
        }
        private ICollection<UserRole> CreateUserRoles(ICollection<int> roleIds, string logInfoString, Guid operationGroupId, Guid userId)
        {
            return roleIds
                .Select(roleId => CreateUserRole(roleId, logInfoString, operationGroupId, userId))
                .ToList();
        }
        private UserRole CreateUserRole(int roleId, string logInfoString, Guid operationGroupId, Guid userId)
        {
            return new UserRole()
            {
                RoleId = roleId,
                InsertGroupId = operationGroupId,
                InsertLogInfo = logInfoString,
                //ValidFrom = DateTime.Now,
                ValidTo = null,
                UserId = userId
            };
        }
    }
}