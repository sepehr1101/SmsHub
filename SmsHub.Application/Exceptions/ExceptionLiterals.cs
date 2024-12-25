namespace SmsHub.Application.Exceptions
{
    public static class ExceptionLiterals
    {
        public static string ProviderException => "احراز هویت _Provider {0}_ ناصحیح است";
        public static string InvalidTemplateId => "کد -قالب پیامک- نامعتبر است";
        public static string InvalidLineId => "کد -شماره خط- نامعتبر است";
        public static string InvalidUserData => "مقادیر وارد شده با قالب ناسازگار است";
        public static string InvalidMobile => "ویژگی Mobile را وارد کنید";
        public static string InvalidProviderId => "کد Provider نامعتبر است";
        public static string InvalidProviderHandle=> "ارسال کننده خط از این عملیات پشتیبانی نمی کند";


    }
}
