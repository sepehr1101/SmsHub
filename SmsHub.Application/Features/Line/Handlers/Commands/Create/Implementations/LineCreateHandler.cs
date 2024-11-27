using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Line.Commands.Contracts;
using SmsHub.Application.Features.Line.Handlers.Commands.Create.Contracts;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using FluentValidation;
using Newtonsoft.Json;
using MagfaCredentialDto = SmsHub.Domain.Providers.Magfa3000.Entities.Responses.CredentialDto;
using KavenegarCredentialDto = SmsHub.Domain.Providers.Kavenegar.Entities.Responses.CredentialDto;
using SmsHub.Domain.Constants;
using SmsHub.Application.Exceptions;

namespace SmsHub.Application.Features.Line.Handlers.Commands.Create.Implementations
{
    public class LineCreateHandler : /*IRequestHandler<CreateLineDto>,*/ ILineCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly ILineCommandService _lineCommandService;
        private readonly IValidator<CreateLineDto> _validator;
        public LineCreateHandler(IMapper mapper, ILineCommandService lineCommandService, IValidator<CreateLineDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _lineCommandService = lineCommandService;
            _lineCommandService.NotNull(nameof(_lineCommandService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }

        public async Task Handle(CreateLineDto request, CancellationToken cancellationToken)
        {
            ValidationProvider(request);

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException("خطا در اطلاعات ورودی");
            }

            var line = _mapper.Map<Entities.Line>(request);
            await _lineCommandService.Add(line);
        }
        public void ValidationProvider(CreateLineDto createDto)
        {
            if (createDto.Credential == null)
            {
                throw new ProviderCredentialException("");
            }
            else
            {
                switch (createDto.ProviderId)
                {
                    case ProviderEnum.Magfa:
                        var resultMagfaDeserialize = DeserializeCredential<MagfaCredentialDto>(createDto.Credential);
                        if (resultMagfaDeserialize != null)
                        {
                            if (string.IsNullOrWhiteSpace(resultMagfaDeserialize.Domain))
                                throw new ProviderCredentialException("مگفا");
                            if (string.IsNullOrWhiteSpace(resultMagfaDeserialize.UserName))
                                throw new ProviderCredentialException("مگفا");
                            if (string.IsNullOrWhiteSpace(resultMagfaDeserialize.ClientSecret))
                                throw new ProviderCredentialException("مگفا");
                        }
                        else
                        {
                            throw new ProviderCredentialException("مگفا");
                        }
                        break;

                    case ProviderEnum.Kavenegar:
                        var resultKavenegarDeserialize = DeserializeCredential<KavenegarCredentialDto>(createDto.Credential);
                        if (resultKavenegarDeserialize != null)
                        {
                            if (string.IsNullOrWhiteSpace(resultKavenegarDeserialize.apiKey ))
                                throw new ProviderCredentialException("کاوه نگار");
                        }
                        else
                        {
                            throw new ProviderCredentialException("کاوه نگار");
                        }
                        break;

                    default:
                        throw new ProviderCredentialException("");

                }
            }
        }

        public T DeserializeCredential<T>(string credential)
        {
            T resultDeserialize;
            try
            {
                resultDeserialize = JsonConvert.DeserializeObject<T>(credential);
            }
            catch
            {
                throw new ProviderCredentialException("");
            }

            return resultDeserialize;
        }
    }
}
