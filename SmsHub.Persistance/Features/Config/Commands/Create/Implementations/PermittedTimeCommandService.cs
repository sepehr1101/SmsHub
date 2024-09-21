using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Config.Commands.Create.Contracts;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Config.Commands.Create.Implementations
{
    public class PermittedTimeCommandService: IPermittedTimeCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Entities.PermittedTime> _permittedTimes;
        public PermittedTimeCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _permittedTimes = _uow.Set<Entities.PermittedTime>();
        }

        public async Task Add(Entities.PermittedTime permittedTime)
        {
            await _permittedTimes.AddAsync(permittedTime);
        }
        public async Task Add(ICollection<Entities.PermittedTime> permittedTime)
        {
            await _permittedTimes.AddRangeAsync(permittedTime);
        }
    }
}
