namespace SmsHub.Domain.Constants
{
    public static class LogLevelMessageResources
    {
        #region Section
        public static string SendConfigSection { get { return "کانفیگ ارسال"; } }
        #endregion





        #region Description

        #region Config
        public static string AddCcSendDescription { get { return "CcSend افزوده شد"; } }
        public static string AddConfigDescription { get { return "Config افزوده شد"; } }
        public static string AddConfigTypeGroupDescription { get { return "ConfigTypeGroup افزوده شد"; } }
        public static string AddDisallowedPhraseDescription { get { return "DisallowedPhrase افزوده شد"; } }
        public static string AddPermittedTimeDescription { get { return "PermittedTime افزوده شد"; } }

        public static string DeleteCcSendDescription { get { return "CcSend حذف شد"; } }
        public static string DeleteConfigDescription { get { return "Config حذف شد"; } }
        public static string DeleteConfigTypeGroupDescription { get { return "ConfigTypeGroup حذف شد"; } }
        public static string DeleteDisallowedPhraseDescription { get { return "DisallowedPhrase حذف شد"; } }
        public static string DeletePermittedTimeDescription { get { return "PermittedTime حذف شد"; } }

        public static string UpdateCcSendDescription { get { return "CcSend ویرایش شد"; } }
        public static string UpdateConfigDescription { get { return "Config ویرایش شد"; } }
        public static string UpdateConfigTypeGroupDescription { get { return "ConfigTypeGroup ویرایش شد"; } }
        public static string UpdateDisallowedPhraseDescription { get { return "DisallowedPhrase ویرایش شد"; } }
        public static string UpdatePermittedTimeDescription { get { return "PermittedTime ویرایش شد"; } }

        public static string GetCcSendDescription(int count) => $" تعداد {count.ToString()} رکورد از CcSend نمایش داده شد ";
        public static string GetConfigDescription(int count) => $" تعداد {count.ToString()} رکورد از Config نمایش داده شد ";
        public static string GetConfigTypeGroupDescription(int count) => $" تعداد {count.ToString()} رکورد از ConfigTypeGroup نمایش داده شد ";
        public static string GetDisallowedPhraseDescription(int count) => $" تعداد {count.ToString()} رکورد از DisallowedPhrase نمایش داده شد ";
        public static string GetPermittedTimeDescription(int count) => $" تعداد {count.ToString()} رکورد از PermittedTime نمایش داده شد ";
        #endregion
        #region Contact

        #endregion
        public static string AddContactCategoryDescription { get { return "ContactCategory افزوده شد"; } }
        public static string AddContactDescription { get { return "Contact افزوده شد"; } }
        public static string AddContactNumberCategoryDescription { get { return "ContactNumberCategory افزوده شد"; } }
        public static string AddContactNumberDescription { get { return "ContactNumber افزوده شد"; } }
        
        public static string DeleteContactCategoryDescription { get { return "ContactCategory حذف شد"; } }
        public static string DeleteContactDescription { get { return "Contact حذف شد"; } }
        public static string DeleteContactNumberCategoryDescription { get { return "ContactNumberCategory حذف شد"; } }
        public static string DeleteContactNumberDescription { get { return "ContactNumber حذف شد"; } }
        
        public static string UpdateContactCategoryDescription { get { return "ContactCategory ویرایش شد"; } }
        public static string UpdateContactDescription { get { return "Contact ویرایش شد"; } }
        public static string UpdateContactNumberCategoryDescription { get { return "ContactNumberCategory ویرایش شد"; } }
        public static string UpdateContactNumberDescription { get { return "ContactNumber ویرایش شد"; } }

        #endregion
    }
}
