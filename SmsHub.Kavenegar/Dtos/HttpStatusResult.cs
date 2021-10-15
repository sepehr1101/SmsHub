using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SmsHub.Kavenegar.Dtos
{
    public class HttpStatusResult
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public string Message { get; set; }
    }
}
