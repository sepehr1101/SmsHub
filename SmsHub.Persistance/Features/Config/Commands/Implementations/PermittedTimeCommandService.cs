using Microsoft.EntityFrameworkCore;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Config.Commands.Contracts;

namespace SmsHub.Persistence.Features.Config.Commands.Implementations
{
    public class PermittedTimeCommandService : IPermittedTimeCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<PermittedTime> _permittedTimes;
        public PermittedTimeCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _permittedTimes = _uow.Set<PermittedTime>();
        }

        public async Task Add(PermittedTime permittedTime)
        {
            await _permittedTimes.AddAsync(permittedTime);
        }
        public async Task Add(ICollection<PermittedTime> permittedTime)
        {
            await _permittedTimes.AddRangeAsync(permittedTime);
        }
        public void Delete(PermittedTime permittedTime)
        {
            _permittedTimes.Remove(permittedTime);
        }
    }
}
