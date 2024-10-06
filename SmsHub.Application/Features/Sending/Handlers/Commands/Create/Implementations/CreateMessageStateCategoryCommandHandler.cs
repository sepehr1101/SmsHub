using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Implementations
{
    public class CreateMessageStateCategoryCommandHandler : ICreateMessageStateCategoryCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageStateCategoryCommandService _messageStateCategoryCommandService;
        public CreateMessageStateCategoryCommandHandler(IMapper mapper, IMessageStateCategoryCommandService messageStateCategoryCommandService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _messageStateCategoryCommandService = messageStateCategoryCommandService;
            _messageStateCategoryCommandService.NotNull(nameof(_messageStateCategoryCommandService));
        }

        public async Task Handle(CreateMessageStateCategoryDto request, CancellationToken cancellationToken)
        {
            var messageStateCategory = _mapper.Map<Entities.MessageStateCategory>(request);
            await _messageStateCategoryCommandService.Add(messageStateCategory);
        }
    }
}
