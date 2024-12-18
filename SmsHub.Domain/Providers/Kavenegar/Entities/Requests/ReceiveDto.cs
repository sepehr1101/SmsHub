using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Kavenegar.Entities.Requests
{
    public class ReceiveDto
    {
        public string LineNumber { get; set; }
        public short IsRead { get; set; }

        public ReceiveDto(string lineNumber, bool isRead)
        {
            if (lineNumber.Length <= 2 || IsRead > 1 || IsRead < 0)
                throw new InvalidDataException();

            LineNumber = lineNumber;
            IsRead = isRead?(short)1:(short)0;
        }

    }
}
