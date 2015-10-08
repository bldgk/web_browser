using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.Win32;
using WebKit.Interop;
using System.Net.Http;
using System.Windows.Forms;

namespace WBTest
{
    class Program
    {
        public delegate void Del(string message);
        static void Main(string[] args)
        {
           System.Net.IPAddress ip = Dns.GetHostByName("www.vk.com").AddressList[0];
            Console.WriteLine(ip.ToString());

           // var req = WebRequest.Create("http://vk.com");
           // string reqstring;

           // using (var reader = new StreamReader(req.GetResponse().GetResponseStream()))
           // {
           //     reqstring = reader.ReadToEnd();
           // }
           // string[] a = reqstring.Split(':');
           // string a2 = a[1].Substring(1);
           // string[] a3 = a2.Split('<');
           // string ipp = a3[0];

           // Console.WriteLine(ipp);
           ///// Console.WriteLine(GetPublicIpAddress());
           // Console.WriteLine(GetPublicIP());

            Del handler = DelegateMethod;
            handler("hello world");
            MethodWithCallback(1, 2, handler);
            handler = DelegateMethodReverse;
            handler("hello world");       
            MethodWithCallback(1, 2, handler);
            ABC ac = null;//= new ABC(3);
            Console.WriteLine(AppendChild(ac));

            Console.ReadKey();
        }
        
                public static void DelegateMethod(string message)
        {
            System.Console.WriteLine(message);
        }
        public static void DelegateMethodReverse(string message)
        {
            string text = String.Empty;
            foreach (var t in message.Reverse().ToList())
                text += t.ToString();
            Console.WriteLine(text);
        }
        public static void MethodWithCallback(int param1, int param2, Del callback)
        {
            callback("The number is: "+(param1+ param2).ToString());
        }
        public static  string AppendChild(ABC NewChild)
        {
            //if (NewChild != null )
            //    throw new ArgumentNullException();
            return NewChild?.GetA();
          //  throw new ArgumentNullException();
        }
    }
    public class ABC
    {
        public int A { get; set; }
        public ABC()
        {
            A = 0;
        }
        public string GetA()
        {
            return A.ToString();
        }
        public ABC(int a)
        {
            A = a;
        }


    }

}