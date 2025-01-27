using AutoMapper;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Logging.Commands.Contracts;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts;
using FluentValidation;
using SmsHub.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Create.Implementations
{
    public class InformativeLogCreateHandler : IInformativeLogCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IInformativeLogCommandService _informativeLogCommandService;
        private readonly IValidator<CreateInformativeLogDto> _validator;
        private readonly IHttpContextAccessor _contextAccessor;
        public InformativeLogCreateHandler(
            IMapper mapper,
            IInformativeLogCommandService informativeLogCommandService, 
            IValidator<CreateInformativeLogDto> validator,
            IHttpContextAccessor contextAccessor)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _informativeLogCommandService = informativeLogCommandService;
            _informativeLogCommandService.NotNull(nameof(_informativeLogCommandService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));

            _contextAccessor = contextAccessor;
            _contextAccessor.NotNull(nameof(_contextAccessor));
        }

        public async Task Handle(CreateInformativeLogDto createInformativeLogDto, CancellationToken cancellationToken)
        {
            await CheckValidator(createInformativeLogDto, cancellationToken);

            var informativeLog = _mapper.Map<Entities.InformativeLog>(createInformativeLogDto);

            informativeLog.ClientInfo = GetClientInfo();
            informativeLog.Ip = _contextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            informativeLog.InsertDateTime = DateTime.Now;

            await _informativeLogCommandService.Add(informativeLog);
        }
        private async Task CheckValidator(CreateInformativeLogDto createInformativeLogDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(createInformativeLogDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new FluentValidationException(message);
            }
        }
        public string GetClientInfo()
        {
            var logInfo = DeviceDetection.GetLogInfo(_contextAccessor.HttpContext.Request);
            var logInfoString = JsonOperation.Marshal(logInfo);

            return logInfoString;
        }


    }
}
