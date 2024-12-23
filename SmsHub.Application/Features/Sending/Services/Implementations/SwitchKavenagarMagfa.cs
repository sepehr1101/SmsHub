using SmsHub.Application.Features.Line.Handlers.Queries.Contracts;
using SmsHub.Application.Features.Sending.Services.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;

namespace SmsHub.Application.Features.Sending.Services.Implementations
{
    public class SwitchKavenagarMagfa: ISwitchKavenagarMagfa
    {
        private readonly ILineGetSingleHandler _lineGetSingle;
        private readonly ISmsClientKevenegar _smsClientKavenegar;
        private readonly ISmsClientMagfa _smsClientMagfa;
        public SwitchKavenagarMagfa(ILineGetSingleHandler lineGetSingle,
            ISmsClientKevenegar smsClientKavenegar,
            ISmsClientMagfa smsClientMagfa)
        {
            _lineGetSingle = lineGetSingle;
            _lineGetSingle.NotNull(nameof(lineGetSingle));

            _smsClientKavenegar=smsClientKavenegar;
            _smsClientKavenegar.NotNull(nameof(smsClientKavenegar));

            _smsClientMagfa=smsClientMagfa;
            _smsClientMagfa.NotNull(nameof(smsClientMagfa));
        }

        public async Task SwitchAcountBalance(int lineId)
        {
            var line = await _lineGetSingle.Handle(lineId);
            switch (line.ProviderId)
            {
                case ProviderEnum.Magfa:
                    {
                          await _smsClientMagfa.BalanceMagfaTest();
                        break;
                    }
                case ProviderEnum.Kavenegar:
                    {
                        await _smsClientKavenegar.AcountKaveTest();
                        break;
                    }
                default:
                    throw new InvalidCastException();
            }
        }


        public async Task SwitchSend()
        {
            
        }
    }
}
