using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SmsHub.Core.Dtos
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseMessage HttpResponseMessage { get; set; }
        public T ResponseBody { get; set; }
        public string Error { get; set; }
    }
}
