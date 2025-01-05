using SmsHub.Common.Extensions;
using SmsHub.Persistence.Contexts.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SmsHub.Domain.Features.Security.Entities;
using SmsHub.Persistence.Features.Security.Queries.Contracts;

namespace SmsHub.Persistence.Features.Security.Queries.Implementations
{
    public class TokenStoreQueryService : ITokenStoreQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<UserToken> _userTokens;
        public TokenStoreQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _userTokens = _uow.Set<UserToken>();
            _userTokens.NotNull(nameof(_userTokens));
        }
        public async Task<UserToken?> Get(string refreshTokenHash)
        {
            return await _userTokens
                .AsNoTracking()
                .Include(u => u.User)
                .FirstOrDefaultAsync(u =>
                    u.RefreshTokenIdHash == refreshTokenHash &&
                    u.RefreshTokenExpiresDateTime >= DateTime.Now);
        }
    }
}
