using AutoMapper;
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
    public class LineCreateHandler : ILineCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly ILineCommandService _lineCommandService;
        private readonly IValidator<CreateLineDto> _validator;
        public LineCreateHandler(
            IMapper mapper,
            ILineCommandService lineCommandService,
            IValidator<CreateLineDto> validator)
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
            createDto.NotNull(nameof(createDto));

            switch (createDto.ProviderId)
            {
                case ProviderEnum.Magfa:
                    var resultMagfaDeserialize = DeserializeCredential<MagfaCredentialDto>(createDto.Credential);
                    if (resultMagfaDeserialize != null)
                    {
                        if (string.IsNullOrWhiteSpace(resultMagfaDeserialize.Domain))
                            throw new ProviderCredentialByInvalidPropertyException(ExceptionLiterals.Magfa, ExceptionLiterals.Domain);
                        if (string.IsNullOrWhiteSpace(resultMagfaDeserialize.UserName))
                            throw new ProviderCredentialByInvalidPropertyException(ExceptionLiterals.Magfa, ExceptionLiterals.UserName);
                        if (string.IsNullOrWhiteSpace(resultMagfaDeserialize.ClientSecret))
                            throw new ProviderCredentialByInvalidPropertyException(ExceptionLiterals.Magfa, ExceptionLiterals.ClientSecret);
                    }
                    else
                    {
                        throw new ProviderCredentialByNullPropertyException(ExceptionLiterals.Magfa);
                    }
                    break;

                case ProviderEnum.Kavenegar:
                    var resultKavenegarDeserialize = DeserializeCredential<KavenegarCredentialDto>(createDto.Credential);
                    if (resultKavenegarDeserialize != null)
                    {
                        if (string.IsNullOrWhiteSpace(resultKavenegarDeserialize.apiKey))
                            throw new ProviderCredentialByInvalidPropertyException(ExceptionLiterals.Kavenegar, ExceptionLiterals.ApiKey);
                    }
                    else
                    {
                        throw new ProviderCredentialByNullPropertyException(ExceptionLiterals.Kavenegar);
                    }
                    break;

                default:
                    throw new InvalidProviderException();

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
                throw new ProviderCredentialException();
            }

            return resultDeserialize;
        }
    }
}
