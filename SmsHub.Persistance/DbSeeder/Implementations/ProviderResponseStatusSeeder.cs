using Microsoft.EntityFrameworkCore;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.DbSeeder.Contracts;

namespace SmsHub.Persistence.DbSeeder.Implementations
{
    public class ProviderResponseStatusSeeder : IDataSeeder
    {
        public int Order { get; set; } = 10;
        private readonly IUnitOfWork _uow;
        private readonly DbSet<ProviderResponseStatus> _providerResponseStatus;
        public ProviderResponseStatusSeeder(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _providerResponseStatus = _uow.Set<ProviderResponseStatus>();
            _providerResponseStatus.NotNull(nameof(_providerResponseStatus));
        }
        public void SeedData()
        {
            if (!_providerResponseStatus.Any())
            {
                _providerResponseStatus.AddRange(KavenegarStatus());
                _providerResponseStatus.AddRange(MagfaStatus());

                _uow.SaveChanges();
            }
        }

        private List<ProviderResponseStatus> KavenegarStatus()
        {
            var kavenagerSatatusList = new List<ProviderResponseStatus>()
            {
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 200,
                     Message = "درخواست تایید شد",
                     IsSuccess = true,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 400,
                     Message = "پارامترها ناقص هستند",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 401,
                     Message = "حساب کاربری غیرفعال شده است",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 402,
                     Message = "عملیات ناموفق بود",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 403,
                     Message = "کد شناسائی API-Key معتبر نمی‌باشد",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 404,
                     Message = "متد نامشخص است",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 405,
                     Message = "متد Get/Post اشتباه است",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 406,
                     Message = "پارامترهای اجباری خالی ارسال شده اند",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 407,
                     Message = "دسترسی به اطلاعات مورد نظر برای شما امکان پذیر نیست\r\nبرای استفاده از متدهای Select، SelectOutbox و LatestOutBox و یا ارسال با خط بین المللی نیاز به تنظیم IP در بخش تنظیمات امنیتی می باشد",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 409,
                     Message = "سرور قادر به پاسخگوئی نیست بعدا تلاش کنید",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 411,
                     Message = "دریافت کننده نامعتبر است",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 412,
                     Message = "ارسال کننده نامعتبر است",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 413,
                     Message = "پیام خالی است و یا طول پیام بیش از حد مجاز می‌باشد. حداکثر طول کل متن پیامک 900 کاراکتر می باشد",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 414,
                     Message = " حجم درخواست بیشتر از حد مجاز است ،ارسال پیامک :هر فراخوانی حداکثر 200 رکورد و کنترل وضعیت :هر فراخوانی 500 رکورد",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 415,
                     Message = "اندیس شروع بزرگ تر از کل تعداد شماره های مورد نظر است",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 416,
                     Message = "IP سرویس مبدا با تنظیمات مطابقت ندارد",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 417,
                     Message = "تاریخ ارسال اشتباه است و فرمت آن صحیح نمی باشد.",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 418,
                     Message = "اعتبار شما کافی نمی‌باشد",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 419,
                     Message = " طول آرایه متن و گیرنده و فرستنده هم اندازه نیست",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 420,
                     Message = "استفاده از لینک در متن پیام برای شما محدود شده است",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 422,
                     Message = " داده ها به دلیل وجود کاراکتر نامناسب قابل پردازش نیست",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 424,
                     Message = "الگوی مورد نظر پیدا نشد",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 426,
                     Message = " استفاده از این متد نیازمند سرویس پیشرفته می‌باشد",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 427,
                     Message = "استفاده از این خط نیازمند ایجاد سطح دسترسی می باشد",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 428,
                     Message = " ارسال کد از طریق تماس تلفنی امکان پذیر نیست",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 429,
                     Message = "IP محدود شده است",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 431,
                     Message = "ساختار کد صحیح نمی‌باشد",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 432,
                     Message = "پارامتر کد در متن پیام پیدا نشد",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 451,
                     Message = "فراخوانی بیش از حد در بازه زمانی مشخص IP محدود شده",
                     IsSuccess = false,
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Kavenegar,
                     StatusCode = 501,
                     Message = "فقط امکان ارسال پیام تست به شماره صاحب حساب کاربری وجود دارد",
                     IsSuccess = false,
                 },

            };

            return kavenagerSatatusList;
        }

        private List<ProviderResponseStatus> MagfaStatus()
        {
            var magfaStatusList = new List<ProviderResponseStatus>()
            {
                 new ProviderResponseStatus()
                 {
                      ProviderId = ProviderEnum.Magfa,
                      StatusCode = 0,
                      Message = "انجام بدون خطای درخواست",
                      IsSuccess = true
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 1,
                     Message = "شماره گيرنده نادرست است",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 2,
                     Message = "شماره فرستنده نادرست است",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 3,
                     Message = "پارامتر encoding نامعتبراست. (بررسی صحت و هم‌خوانی متن پيامک با encoding انتخابی)",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 4,
                     Message = "پارامتر mclass نامعتبر است",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 6,
                     Message = "پارامتر UDH نامعتبر است",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 8,
                     Message = "زمان ارسال پيامک، خارج از باره‌ی مجاز ارسال پيامک تبليغاتی (۷ الی ۲۲) است",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 13,
                     Message = "محتويات پيامک (تركيب UDH و متن) خالی است. (بررسی دوباره‌ی متن پيامک و پارامتر UDH)",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 14,
                     Message = "مانده اعتبار ريالی مورد نياز برای ارسال پیامک کافی نيست",
                     IsSuccess = false
                 },
                new ProviderResponseStatus()
                {
                    ProviderId = ProviderEnum.Magfa,
                    StatusCode = 15,
                    Message = "سرور در هنگام ارسال پيام مشغول برطرف نمودن ايراد داخلی بوده است. (ارسال مجدد درخواست)",
                    IsSuccess = false
                },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 16,
                     Message = "حساب غيرفعال است. (تماس با واحد فروش سيستم‌های ارتباطی)",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 17,
                     Message = "حساب منقضی شده است. (تماس با واحد فروش سيستم‌های ارتباطی)",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 18,
                     Message = "نام كاربری و يا كلمه عبور نامعتبر است. (بررسی مجدد نام كاربری و كلمه عبور)",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 19,
                     Message = "درخواست معتبر نيست. (تركيب نام كاربری، رمز عبور و دامنه اشتباه است. تماس با واحد فروش برای دريافت كلمه عبور جديد)",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 20,
                     Message = "شماره فرستنده به حساب تعلق ندارد",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 22,
                     Message = "اين سرويس برای حساب فعال نشده است",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 23,
                     Message = "در حال حاضر امکان پردازش درخواست جديد وجود ندارد، لطفا دوباره سعی كنيد. (ارسال مجدد درخواست)",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 24,
                     Message = "شناسه پيامک معتبر نيست. (ممكن است شناسه پيامک اشتباه و يا متعلق به پيامكی باشد كه بيش از يک روز از ارسال آن گذشته)",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 25,
                     Message = "نام متد درخواستی معتبر نيست. (بررسی نگارش نام متد با توجه به بخش متدها در اين راهنما)",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 27,
                     Message = "شماره گيرنده در ليست سياه اپراتور قرار دارد. (ارسال پيامک‌های تبليغاتی برای اين شماره امكان‌پذير نيست)",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 28,
                     Message = "شماره گیرنده، بر اساس پیش‌شماره در حال حاضر در مگفا مسدود است",
                     IsSuccess = false
                 },
                new ProviderResponseStatus()
                {
                    ProviderId = ProviderEnum.Magfa,
                    StatusCode = 29,
                    Message = "آدرس IP مبدا، اجازه دسترسی به این سرویس را ندارد",
                    IsSuccess = false
                },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 30,
                     Message = "تعداد بخش‌های پیامک بیش از حد مجاز استاندارد (۲۶۵ عدد) است",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 31,
                     Message = "فرمت JSON‌ ارسالی صحيح نیست",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 33,
                     Message = "مشترک، دريافت پيامک از اين سرشماره را مسدود نموده است (لغو ۱۱)",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 34,
                     Message = "اطلاعات تایید‌شده برای اين شماره وجود ندارد",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 101,
                     Message = "طول آرايه پارامتر messageBodies با طول آرايه گيرندگان تطابق ندارد",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 102,
                     Message = "طول آرايه پارامتر messageClass با طول آرايه گيرندگان تطابق ندارد",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 103,
                     Message = "طول آرايه پارامتر senderNumbers با طول آرايه گيرندگان تطابق ندارد",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 104,
                     Message = "طول آرايه پارامتر udhs با طول آرايه گيرندگان تطابق ندارد",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 105,
                     Message = "طول آرايه پارامتر priorities با طول آرايه گيرندگان تطابق ندارد",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 106,
                     Message = "آرايه‌ی گيرندگان خالی است",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 107,
                     Message = "طول آرايه پارامتر گيرندگان بيشتر از طول مجاز است",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 108,
                     Message = "آرايه‌ی فرستندگان خالی است",
                     IsSuccess = false
                 },
                 new ProviderResponseStatus()
                 {
                     ProviderId = ProviderEnum.Magfa,
                     StatusCode = 109,
                     Message = "طول آرايه پارامتر encoding با طول آرايه گيرندگان تطابق ندارد",
                     IsSuccess = false
                 },
                new ProviderResponseStatus()
                {
                    ProviderId = ProviderEnum.Magfa,
                    StatusCode = 110,
                    Message = "طول آرايه پارامتر checkingMessageIds با طول آرايه گيرندگان تطابق ندارد",
                    IsSuccess = false
                },
            };

            return magfaStatusList;
        }
    }
}
