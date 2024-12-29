using SmsHub.Application.Common.Services.Implementations;
using SmsHub.Application.Exceptions;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Update;

namespace SmsHub.Application.Features.Line.Validations
{
    public static class LineCredentialValidation
    {
        public static void ValidationCreateLine(CreateLineDto createDto)
        {
            createDto.NotNull(nameof(createDto));
            ValidationProvider(createDto.ProviderId, createDto.Credential);
        }


        public static void ValidationUpdateLine(UpdateLineDto createDto)
        {

            createDto.NotNull(nameof(createDto));
            ValidationProvider(createDto.ProviderId, createDto.Credential);
        }
        public static void ValidationProvider(ProviderEnum providerId, string credential)
        {

            switch (providerId)
            {
                case ProviderEnum.Magfa:
                    var resultMagfaDeserialize = ProviderCredentialService.CheckMagfaValidCredential(credential);
                    break;

                case ProviderEnum.Kavenegar:
                    var resultKavenegarDeserialize = ProviderCredentialService.CheckKavenegarValidCredential(credential);
                    break;

                default:
                    throw new InvalidProviderException();

            }
        }

    }
}