using MediatR;

namespace SmsHub.Domain.Features.Contact.MediatorDtos.Commands
{
    public record CreateContactNumberDto : IRequest
    {
        public string? Number { get; set; }
        public int ContactCategoryId { get; set; }
        public int ContactNumberCategoryId { get; set; }
    }
}
