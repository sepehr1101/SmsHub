using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Security.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Persistence.Features.Security.Commands.Contracts;
using SmsHub.Persistence.Features.Security.Queries.Contracts;

namespace SmsHub.Application.Features.Security.Handlers.Commands.Update.Implementations
{
    public class UserLineUpdateHandler : IUserLineUpdateHandler
    {
        private readonly IUserLineCommandService _userLineCommandService;
        private readonly IUserLineQueryService _userLineQueryService;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateUserLineDto> _validator;

        public UserLineUpdateHandler(
            IUserLineCommandService userLineCommandService,
            IUserLineQueryService userLineQueryService,
            IMapper mapper,
            IValidator<UpdateUserLineDto> validator)
        {
            _userLineCommandService= userLineCommandService;
            _userLineCommandService.NotNull(nameof(userLineCommandService));

            _userLineQueryService= userLineQueryService;
            _userLineQueryService.NotNull(nameof(userLineQueryService));

            _mapper= mapper;
            _mapper.NotNull(nameof(mapper));    

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }

        public async Task Handle(UpdateUserLineDto updateUserLineDto, CancellationToken cancellationToken)
        {
            await CheckValidator(updateUserLineDto, cancellationToken);

            var userLine = await _userLineQueryService.GetById(updateUserLineDto.Id);
            if (userLine == null)
            {
                throw new InvalidDataException();
            }

           var x= _mapper.Map( updateUserLineDto, userLine);
        }
        private async Task CheckValidator(UpdateUserLineDto updateUserLineDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateUserLineDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }
        }

    }
}
