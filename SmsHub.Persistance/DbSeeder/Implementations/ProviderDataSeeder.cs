using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.DbSeeder.Contracts;

namespace SmsHub.Persistence.DbSeeder.Implementations
{
    public class ProviderDataSeeder:IDataSeeder
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Provider> _providers;
        public ProviderDataSeeder(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _providers=_uow.Set<Provider>();
        }

        public int Order { get; set; } = 1;

        public void SeedData()
        {
            if(_providers.Any())
            {
                return;
            }
            var magfa = new Provider()
            {
                BaseUri = @"https://sms.magfa.com/",
                BatchSize = 200,
                DefaultPreNumber = @"3000",
                FallbackBaseUri = @"http://10.7.217.99/",
                Title = "مگفا",
                Website = "sms.magfa.com",
                Id=ProviderEnum.Magfa,
                CredentialTemplate= @"{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }"
            };
            var kavenegar = new Provider()
            {
                BaseUri = @"https://api.kavenegar.com/v1/",
                BatchSize = 200,
                DefaultPreNumber = null,
                Title = "کاوه نگار",
                Website = "kavenegar.com",
                FallbackBaseUri = null,
                Id=ProviderEnum.Kavenegar,
                CredentialTemplate= @"{'apiKey': '---' }"
            };
            var rahyabDate = new Provider()
            {
                BaseUri = @"https://api.payamak-panel.com/post/",
                BatchSize = 200,
                DefaultPreNumber = null,
                Title = "رهیاب رایانه گستر",
                Website = "melipayamak.com",
                FallbackBaseUri = null,
                Id=ProviderEnum.RahyabDate,
                CredentialTemplate= @"{'username': '---','password':'---' }"
            };
            var atiye = new Provider()
            {
                BaseUri = @"https://ippanel.com/service/",
                BatchSize = 200,
                DefaultPreNumber = null,
                Title = "آتیه داده پرداز",
                Website = "atiyehdateh.com",
                FallbackBaseUri = null,
                Id=ProviderEnum.Atiye,
                CredentialTemplate= @"{'uname': '---','pass':'---' }"
            };
            var rahyabPayam = new Provider()
            {
                BaseUri = @"https://parsgreen.com/Web-Service/v1/",
                BatchSize = 200,
                DefaultPreNumber = null,
                Title = "رهیاب پیام گستران",
                Website = "parsgereen.com",
                FallbackBaseUri = null,
                Id=ProviderEnum.RahyabPayam,
                CredentialTemplate= @"{'uname': '---','pass':'---' }"
            };
            var farazSms = new Provider()
            {
                BaseUri = @"https://farazsms.com/api/",
                BatchSize = 200,
                DefaultPreNumber = null,
                Title = "رهیاب پیام گستران",
                Website = "farazsms.com",
                FallbackBaseUri = null,
                Id=ProviderEnum.FarazSms,
                CredentialTemplate= @"{'uname': '---','pass':'---', 'key':'---' }"
            };
            _providers.Add(magfa);
            _providers.Add(kavenegar);
        }
    }
}
