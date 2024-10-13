using SmsHub.Common.Exceptions;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace SmsHub.Common.Extensions
{
    public static class IpValidations
    {
        public static void CheckValidIpV4(string ip)
        {           
            string pattern = @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
            bool result = Regex.IsMatch(ip, pattern);
            if (!result)
            {
                throw new InvalidIpException(ip);
            }
        }

        public static void CheckValidIpV6(string ip)
        {            
            if (!IsValidIPv6(ip))
            {
                throw new InvalidIpException(ip);
            }
        }

        static bool IsValidIPv6(string ipAddress)
        {
            if(ipAddress is null)
            {
                return false;
            }
            if (ipAddress.Contains("999"))
            {
                return false;
            }
            if (IPAddress.TryParse(ipAddress, out IPAddress address))
            {               
                return address.AddressFamily == AddressFamily.InterNetworkV6;
            }

            return false;
        }

    }
}
