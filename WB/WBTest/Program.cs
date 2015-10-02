using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WBTest
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Net.IPAddress ip = Dns.GetHostByName("www.vk.com").AddressList[0];

            Console.WriteLine(ip.ToString());

            var req = WebRequest.Create("http://vk.com");
            string reqstring;

            using (var reader = new StreamReader(req.GetResponse().GetResponseStream()))
            {
                reqstring = reader.ReadToEnd();
            }
            string[] a = reqstring.Split(':');
            string a2 = a[1].Substring(1);
            string[] a3 = a2.Split('<');
            string ipp = a3[0];

            Console.WriteLine(ipp);
           /// Console.WriteLine(GetPublicIpAddress());
            Console.WriteLine(GetPublicIP());
            Console.ReadKey();
        }
        private static string GetPublicIpAddress()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://ifconfig.me");

            request.UserAgent = "curl"; // this simulate curl linux command

            string publicIPAddress;

            request.Method = "GET";

            WebResponse response = request.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    publicIPAddress = reader.ReadToEnd();
                }
            


            return publicIPAddress.Replace("\n", "");
        }
        public static string GetPublicIP()
        {
            string url = "http://vk.com";
            WebRequest req = System.Net.WebRequest.Create(url);
            WebResponse resp = req.GetResponse();
            StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            string response = sr.ReadToEnd().Trim();
            string[] a = response.Split(':');
            //string a2 = a[1].Substring(1);
            //string[] a3 = a2.Split('<');
            //string a4 = a3[0];
            return response;
        }
    }
}