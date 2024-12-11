using SmsHub.Common.Extensions;

namespace SmsHub.Domain.BaseDomainEntities.Id
{
    public record GuidId
    {
        public Guid Id { get; private set; }
        public GuidId(Guid id)
        {
            id.NotEmptyString(nameof(id));

            Id = id; 
        }

        public static implicit operator GuidId(Guid id) => new GuidId(id);
    }
}
