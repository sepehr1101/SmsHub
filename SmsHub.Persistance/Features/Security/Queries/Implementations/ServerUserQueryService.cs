using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Security.Queries.Contracts;

namespace SmsHub.Persistence.Features.Security.Queries.Implementations
{
    public class ServerUserQueryService : IServerUserQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<ServerUser> _users;
        public ServerUserQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _users = _uow.Set<ServerUser>();
            _users.NotNull(nameof(_users));
        }
        public async Task<ServerUser> GetByApiKey(string apiKey)
        {
            return await _users.FirstOrDefaultAsync(u => u.ApiKeyHash == apiKey);
        }
        public async Task<bool> Any(string apiKey)
        {
            return await _users.AnyAsync(u=>u.ApiKeyHash == apiKey);
        }
    }
}
