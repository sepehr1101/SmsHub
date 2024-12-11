using SmsHub.Application.Exceptions;
using SmsHub.Common.Exceptions;

namespace SmsHub.Domain.BaseDomainEntities.Id
{
    public record IntId 
    {
        public int Id { get; private set; }
        public IntId(int id)
        {
            if (Id == 0)
                throw new InvalidIdException();
         
            Id = id;
        }

        public static implicit operator IntId(int id)=>new IntId(id);

    }
}
