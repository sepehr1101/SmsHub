using static System.Net.Mime.MediaTypeNames;

namespace SmsHub.Application.Exceptions
{
    public static class ExceptionLiterals
    {
        public static string ProviderWithInvalidProperty(string provider, string prop) => $"احراز هویت -Provider {provider} / ویژگی {prop}- ناصحیح است";
        public static string ProviderWithNullProperty(string provider) => $"احراز هویت -Provider {provider}- بهمراه ویژگی خالی ناصحیح است";
        public static string ProviderCredential => "احراز هویت Provider با چنین Credential ناصحیح است";
        public static string Magfa => "مگفا";
        public static string Kavenegar => "کاوه نگار";
        public static string UserName => "UserName";
        public static string Domain => "Domain";
        public static string ClientSecret => "ClientSecret";
        public static string ApiKey => "ApiKey";


        public static string InvalidTemplateId => "کد -قالب پیامک- نامعتبر است";
        public static string InvalidLineId => "کد -شماره خط- نامعتبر است";
        public static string InvalidUserData => "مقادیر وارد شده با قالب ناسازگار است";
        public static string InvalidMobile => "ویژگی Mobile را وارد کنید";
        public static string InvalidProviderId => "کد Provider نامعتبر است";
        public static string InvalidProviderHandle=> "ارسال کننده خط از این عملیات پشتیبانی نمی کند";


        public static string InvalidProviderResponse(string message, int statusCode) => $"خطا => {message} - {statusCode} ";
        public static string FluentValidationMessage(string message) => $"خطا => {message}";

        public static string MessageError(string message) => $"{message} خطا در مرحله دوم احراز هویت : ";
        public static string InvalidForeignKey(string tebleName) => $"موجودیت {tebleName} ، با شناسه وارد شده یافت نشد";
        public static string DuplicateItem => "این آیتم قبلا قبلا ذخیره شده است";
    }
}
