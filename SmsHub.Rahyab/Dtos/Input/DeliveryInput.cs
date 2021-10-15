using SmsHub.Rahyab.Dtos.Base;
using System;

namespace SmsHub.Rahyab.Dtos.Input
{
    public class DeliveryInput: UserPassCompany
    {
        public Guid BatchId { get; set; }
    }
}
