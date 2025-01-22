using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Security.Queries.Contracts;

namespace SmsHub.Persistence.Features.Security.Queries.Implementations
{
    public class UserLineQueryService : IUserLineQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<UserLine> _userLine;

        public UserLineQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _userLine = _uow.Set<UserLine>();
            _userLine.NotNull(nameof(_userLine));

        }

        public async Task<UserLine> GetById(long Id)
        {
            return await _uow.FindOrThrowAsync<UserLine>(Id);
        }

        public async Task<ICollection<GetUserLineByUserIdDto>> GetUserLinesByUserId(Guid userId)
        {

            return await _userLine
                .Include(l => l.Line)
                .Where(u => u.UserId == userId)
                .Select(l => new GetUserLineByUserIdDto()
                {
                    Id = l.Id,
                    LineId = l.LineId,
                    LineNumber = l.Line.Number,

                }).ToListAsync();

        }

        public async Task<ICollection<GetUserLineByLineIdDto>> GetUserLinesByLineId(int LineId)
        {
            return await _userLine
                .Include(u => u.User)
                .Where(l => l.LineId == LineId)
                .Select(u => new GetUserLineByLineIdDto()
                {
                    Id = u.Id,
                    UserId = u.UserId,
                    FullName = u.User.FullName,
                }).ToListAsync();

        }

    }
}
