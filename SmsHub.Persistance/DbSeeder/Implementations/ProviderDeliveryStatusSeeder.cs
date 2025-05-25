using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.DbSeeder.Contracts;

namespace SmsHub.Persistence.DbSeeder.Implementations
{
    public class ProviderDeliveryStatusSeeder : IDataSeeder
    {
        public int Order { get; set; } = 10;
        private readonly IUnitOfWork _uow;
        private readonly DbSet<ProviderDeliveryStatus> _providerDeliveryStatus;

        public ProviderDeliveryStatusSeeder(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _providerDeliveryStatus = _uow.Set<ProviderDeliveryStatus>();
            _providerDeliveryStatus.NotNull(nameof(_providerDeliveryStatus));
        }
        public void SeedData()
        {
            if (!_providerDeliveryStatus.Any())
            {
                _providerDeliveryStatus.AddRange(GetKavenegarDeliveryStatus());
                _providerDeliveryStatus.AddRange(GetMagfaDeliveryStatus());
                _uow.SaveChanges();
            }
        }
        private List<ProviderDeliveryStatus> GetKavenegarDeliveryStatus()
        {
            var KavenegarDeliveryStatus = new List<ProviderDeliveryStatus>()
            {
                new ProviderDeliveryStatus()
                {
                    ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 1,
                     Message = "در صف ارسال قرار دارد",
                     IsFinal = false,
                },
                new ProviderDeliveryStatus()
                {
                    ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 2,
                     Message = " زمان بندی شده (ارسال در تاریخ معین)",
                     IsFinal = false,
                },
                new ProviderDeliveryStatus()
                {
                    ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 4,
                     Message = " ارسال شده به مخابرات",
                     IsFinal = false,
                },
                new ProviderDeliveryStatus()
                {
                    ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 5,
                     Message = "ارسال شده به مخابرات (همانند وضعیت 4)",
                     IsFinal = false,
                },
                new ProviderDeliveryStatus()
                {
                    ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 6,
                     Message = "خطا در ارسال پیام که توسط سر شماره پیش می آید و به معنی عدم رسیدن پیامک می‌باشد (Failed)",
                     IsFinal = true,
                },
                new ProviderDeliveryStatus()
                {
                    ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 10,
                     Message = "رسیده به گیرنده (Delivered)",
                     IsFinal = true,
                },
                new ProviderDeliveryStatus()
                {
                    ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 11,
                     Message = "نرسیده به گیرنده ، این وضعیت به دلایلی از جمله خاموش یا خارج از دسترس بودن گیرنده اتفاق می افتد (Undelivered)",
                     IsFinal = true,
                },
                new ProviderDeliveryStatus()
                {
                    ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 13,
                     Message = "ارسال پیام از سمت کاربر لغو شده یا در ارسال آن مشکلی پیش آمده که هزینه آن به حساب برگشت داده می‌شود",
                     IsFinal = true,
                },
                new ProviderDeliveryStatus()
                {
                    ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 14,
                     Message = "بلاک شده است، عدم تمایل گیرنده به دریافت پیامک از خطوط تبلیغاتی که هزینه آن به حساب برگشت داده می‌شود",
                     IsFinal = true,
                },
                new ProviderDeliveryStatus()
                {
                    ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 100,
                     Message = "شناسه پیامک نامعتبر است ( به این معنی که شناسه پیام در پایگاه داده کاوه نگار ثبت نشده است یا متعلق به شما نمی‌باشد)",
                     IsFinal = true,
                },       
            };
            return KavenegarDeliveryStatus;
        }
        private List<ProviderDeliveryStatus> GetMagfaDeliveryStatus()
        {
            var MagfaDeliveryStatus = new List<ProviderDeliveryStatus>()
            {
                new ProviderDeliveryStatus()
                {
                    ProviderId = ProviderEnum.Magfa,
                     StatusCode = 0,
                     Message = "ارسال به Provider",
                     IsFinal = false,
                },
                new ProviderDeliveryStatus()
                {
                    ProviderId = ProviderEnum.Magfa,
                     StatusCode = 1,
                     Message = "رسیده به گوشی",
                     IsFinal = true,
                },
                new ProviderDeliveryStatus()
                {
                    ProviderId = ProviderEnum.Magfa,
                     StatusCode = 2,
                     Message = "نرسیده به گوشی",
                     IsFinal = true,
                },
                new ProviderDeliveryStatus()
                {
                    ProviderId = ProviderEnum.Magfa,
                     StatusCode = 8,
                     Message = "رسیده به مخابرات",
                     IsFinal = false,
                },
                new ProviderDeliveryStatus()
                {
                    ProviderId = ProviderEnum.Magfa,
                     StatusCode = 16,
                     Message = "نرسیده به مخابرات",
                     IsFinal = true,
                }
            };
           return MagfaDeliveryStatus;
        }
    }
}
