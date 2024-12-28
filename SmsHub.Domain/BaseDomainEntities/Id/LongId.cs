using SmsHub.Common.Exceptions;

namespace SmsHub.Domain.BaseDomainEntities.Id
{
    public record LongId
    {
        public long Id { get; private set; }
        public LongId(long id)
        {
            if (id == 0)
                throw new InvalidIdException();

            Id = id;
        }

        public static implicit operator LongId(long id) => new LongId(id);
    }
}
