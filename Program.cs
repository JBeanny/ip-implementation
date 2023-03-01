using System;
using System.Net;

namespace IpValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an IP address: ");
            string ipAddressString = Console.ReadLine()!;
            
            string response = IPv4Validator(ipAddressString) ? $"{ipAddressString} is a valid IP address." : $"{ipAddressString} is not a valid IP address.";

            Console.WriteLine(response);
        }
        public static bool IPv4Validator(string ipAddress)
        {   
            // split input string by (".") into array of string 
            string[] octets = ipAddress.Split('.');

            // if octet is not in the length of 4 
            if (octets.Length != 4)
            {
                return false;
            }

            foreach (string octet in octets)
            {
                // if octet starts with 0
                if (octet.Length > 1 && octet[0] == '0')
                {
                    return false;
                }

                // if octet is not 0 < octet < 255
                if (!int.TryParse(octet, out int octetInt) || octetInt < 0 || octetInt > 255)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
