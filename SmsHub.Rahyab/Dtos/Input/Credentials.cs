using SmsHub.Core.Dtos;

namespace SmsHub.Rahyab.Dtos.Input
{
    public class Credentials : UsernamePassword
    {
        public string Company { get; set; }
    }
}
