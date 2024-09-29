using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Security.Commands.Contracts;

namespace SmsHub.Persistence.Features.Security.Commands.Implementations
{
    public class ServerUserCommandService : IServerUserCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<ServerUser> _users;
        public ServerUserCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _users = _uow.Set<ServerUser>();
            _users.NotNull(nameof(_users));
        }

        public async Task Add(ServerUser user)
        {
            await _users.AddAsync(user);
        }
        public async Task Remove(int id)
        {
            var user = await _users.FindAsync(id);
            user.DeleteDateTime = DateTime.Now;
        }
        public async Task UpdateApiKey(int id, string newApiKeyHash)
        {
            var user = await _users.FindAsync(id);
            user.ApiKeyHash = newApiKeyHash;
        }
    }
}