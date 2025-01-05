namespace SmsHub.Domain.Constants
{
    public static class MessageResources
    {
        public const string ItemNotNull = "آیتم تهی وارد شده";
        public const string ItemIsInt = "آیتم باید با فرمت عددی باشد";
        public const string ItemIsShort = "آیتم وارد شده بیش از حد مجاز است";
        public const string ItemIsDateTime = "آیتم با فرمت روز و تاریخ است";
        public const string ItemIsDuplicate = "آیتم وارد شده تکراری است";
        public const string ItemIsBool = "مقادیر مجاز : 0 یا 1";

        public const string ItemNotMoreThan1023 = "تعداد کاراکتر  باید کمتر از 1023 باشد ";
        public const string ItemNotMoreThan255 = "تعداد کاراکتر باید کمتر از 255 باشد";
        public const string ItemNotMoreThan128 = "تعداد کاراکتر باید کمتر از 128 باشد ";
        public const string ItemNotMoreThan64 = "تعداد کاراکتر باید کمتر از 64 باشد";
        public const string ItemNotMoreThan63 = "تعداد کاراکتر باید کمتر از 63 باشد";
        public const string ItemNotMoreThan15 = "تعداد کاراکتر باید کمتر از 15 باشد";
        public const string ItemNotMoreThan11 = "تعداد کاراکتر باید کمتر از 11 باشد";
        public const string ItemNotMoreThan5 = "تعداد کاراکتر باید کمتر از 5 باشد";

        public const string ItemNotLessThan3 = "تعداد کاراکتر نباید کمتر از 3 باشد";
        public const string ItemNotLessThan3_NotMoreThan255 = "تعداد کاراکتر باید بین 3 تا 255 باشد";
        public const string ItemNotLessThan4_NotMoreThan15 = "تعداد کاراکتر باید بین 4 تا 15 باشد";

        public static string SuccessfulProccess { get { return "درخواست با موفقیت پردازش شد"; } }
        public static string CaptchaInvalid { get { return "کپچا نادرست است"; } }
        public static string RefreshTokenIsLessThanToken { get { return "زمان تعیین شده برای انقضای refresh token کمتر از زمان token اصلی در نظر گفته شده است"; } }

    }
}
