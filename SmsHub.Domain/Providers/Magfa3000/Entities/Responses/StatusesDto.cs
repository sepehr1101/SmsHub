using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Magfa3000.Entities.Responses
{
    public class StatusesDto
    {
        public int Status { get; set; }
        public ICollection<DlrsDto> Dlrs { get; set; }

    }
    public class DlrsDto
    {
        public long Mid { get; set; }
        public int Status { get; set; }
        public string Date { get; set; }
    }
}
