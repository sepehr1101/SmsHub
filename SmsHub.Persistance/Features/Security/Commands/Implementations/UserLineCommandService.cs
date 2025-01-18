using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Security.Commands.Contracts;

namespace SmsHub.Persistence.Features.Security.Commands.Implementations
{
    public class UserLineCommandService : IUserLineCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<UserLine> _userLine;

        public UserLineCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _userLine = _uow.Set<UserLine>();
            _userLine.NotNull(nameof(_userLine));

        }
        public async Task Add(UserLine userLine)
        {
            await _userLine.AddAsync(userLine);
        }

        public async Task Add(ICollection<UserLine> userLines)
        {
            await _userLine.AddRangeAsync(userLines);
        }

        public async Task Delete(long userLineId)
        {
            var userLine = await _userLine.FindAsync(userLineId);
             _userLine.Remove(userLine);
        }

    }
}
