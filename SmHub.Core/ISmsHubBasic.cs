using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Core
{
    public interface ISmsHubBasic<SendInput, SendOutput, Credential>
        where SendInput : class
        where SendOutput : class
        where Credential : class
    {
        public Task<SendOutput> Send(SendInput input);
        public Task<SendOutput> Send(ICollection<SendInput> inputs);
        public Task<long> GetCredit(Credential credential);
    }
}
