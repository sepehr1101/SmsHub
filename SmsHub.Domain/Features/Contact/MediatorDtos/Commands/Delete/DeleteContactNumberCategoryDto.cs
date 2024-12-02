using MediatR;
using SmsHub.Domain.Constants;

namespace SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete
{
    public record DeleteContactNumberCategoryDto  
    {
        public int Id { get; init; }

    }
}
