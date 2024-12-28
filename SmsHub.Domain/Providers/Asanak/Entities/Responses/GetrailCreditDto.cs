using SmsHub.Domain.Providers.Asanak.Entities.Base;

namespace SmsHub.Domain.Providers.Asanak.Entities.Responses
{
    public class GetrailCreditDto : ResponseBase
    {
        public GetrialDataDto Data { get; set; }
    }
    public class GetrialDataDto//todo: change class Name
    {
        public long Credit { get; set; }
    }
}
