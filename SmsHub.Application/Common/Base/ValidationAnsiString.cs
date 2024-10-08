namespace SmsHub.Application.Common.Base
{
    public static class ValidationAnsiString
    {
        public static bool Execute(string M)
        {
            return M.All(x => x <= 255);
        }
    }
}
