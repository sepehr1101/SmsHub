using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Kavenegar.Entities.Requests
{
    public class MakettsDto
    {
        public string Receptor { get; set; }
        public string Message { get; set; }
        public long Date { get; set; }
        public string LocalId { get; set; }
        public int Repeat { get; set; }

    }
}
