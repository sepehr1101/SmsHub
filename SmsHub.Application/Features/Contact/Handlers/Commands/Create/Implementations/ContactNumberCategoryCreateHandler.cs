using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Contact.Commands.Contracts;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Contact.Handlers.Commands.Create.Contracts;

namespace SmsHub.Application.Features.Contact.Handlers.Commands.Create.Implementations
{
    public class ContactNumberCategoryCreateHandler : IContactNumberCategoryCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IContactNumberCategoryCommandService _contactNumberCategoryCommandService;
        public ContactNumberCategoryCreateHandler(IMapper mapper, IContactNumberCategoryCommandService contactNumberCategoryCommandService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _contactNumberCategoryCommandService = contactNumberCategoryCommandService;
            _contactNumberCategoryCommandService.NotNull(nameof(_contactNumberCategoryCommandService));
        }

        public async Task Handle(CreateContactNumberCategoryDto request, CancellationToken cancellationToken)
        {
            var contactNumberCategory = _mapper.Map<Entities.ContactNumberCategory>(request);
            await _contactNumberCategoryCommandService.Add(contactNumberCategory);
        }
    }
}
