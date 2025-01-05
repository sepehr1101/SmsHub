using AutoMapper;
using Microsoft.AspNetCore.Http;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Security.Commands.Contracts;
using SmsHub.Persistence.Features.Security.Queries.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Application.Features.Auth.Handlers.Commands.Update.Implementations
{
    public class UserUpdateHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IUserCommandService _userCommandService;
        private readonly IUserQueryService _userQueryService;
        private readonly IUserRoleQueryService _userRoleQueryService;

        private readonly IHttpContextAccessor _contextAccessor;
        public UserUpdateHandler(
            IUnitOfWork uow,
            IMapper mapper,
            IUserCommandService userCommandService,
            IUserQueryService userQueryService,
            IUserRoleQueryService userRoleQueryService,
            IHttpContextAccessor contextAccessor)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _userCommandService = userCommandService;
            _userCommandService.NotNull(nameof(userCommandService));

            _userQueryService = userQueryService;
            _userQueryService.NotNull(nameof(userQueryService));

            _userRoleQueryService = userRoleQueryService;
            _userRoleQueryService.NotNull(nameof(userRoleQueryService));

            _contextAccessor = contextAccessor;
            _contextAccessor.NotNull(nameof(contextAccessor));
        }
        public async Task Handle(UserUpdateDto userUpdateDto, CancellationToken cancellationToken)
        {
            var logInfo = DeviceDetection.GetLogInfo(_contextAccessor.HttpContext.Request);
            var logInfoString= JsonOperation.Marshal(logInfo);
            var userInDb= await _userQueryService.Get(userUpdateDto.Id);
            var user= _mapper.Map<User>(userInDb);
            user.PreviousId = userInDb.Id;
            _userCommandService.Remove(userInDb, logInfoString);
        }
    }
}
