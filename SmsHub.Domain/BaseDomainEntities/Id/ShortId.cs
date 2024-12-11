using SmsHub.Application.Exceptions;

namespace SmsHub.Domain.BaseDomainEntities.Id
{
    public record ShortId
    {
        public short Id { get; private set; }
        public ShortId(short id)
        {
            if (id == 0)
                throw new InvalidIdException();

            Id = id;
        }

        public static implicit operator ShortId(short id) => new ShortId(id);
    }
}
