using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Url_to_Decimal
{
    class Program
    {
        static void Main(string[] args)
        {
            //Requires that the first bit of the url starts with http://, but doesn't check that.
            //Needs the full domain, for example: http://google.com
            Console.WriteLine("{0}", "Please enter a valid url: ");
            String urlToCheck = Console.ReadLine();
            Uri myUri = new Uri(urlToCheck);
            IPAddress ip = Dns.GetHostAddresses(myUri.Host)[0];
            //Split the address into its parts
            string[] partsOfIP = ip.ToString().Split('.');
            String binaryAddress = null;
            //For each part, convert it into its binary equivalent and then
            //generate a string out of it. Make sure the string is 8 characters long
            //Ex. Binary 2 = 10, without padding, you don't get the 8 bit string.
            foreach(String ipPart in partsOfIP)
            {
                binaryAddress += Convert.ToString(Convert.ToInt64(ipPart, 10), 2).PadLeft(8,'0');
            }
            String outputUrl = null;
            //Convert our large binary number into the Decimal equivalent for the url
            outputUrl = Convert.ToString(Convert.ToInt64(binaryAddress, 2), 10);
            Console.WriteLine("{0}", outputUrl);
            Console.ReadLine();
        }
    }
}
