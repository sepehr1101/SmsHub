using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Kavenegar.Entities.Requests
{
    public class LookupDto
    {
        public string Receptor {  get; set; }
        public string Token { get; set; }
        public string ?Token2{ get; set; }
        public string? Token3 { get; set; }
        public string? Template { get; set; }
        public string? Type { get; set; }
    }
}
