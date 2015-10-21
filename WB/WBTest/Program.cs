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
using System.Collections;
using WBCore.DOM;
namespace WBTest
{
    class Program
    {
        public delegate void Del(string message);
        static void Main(string[] args)
        {
            //System.Net.IPAddress ip = Dns.GetHostByName("www.vk.com").AddressList[0];
            // Console.WriteLine(ip.ToString());
            //List<String> Strings = new List<string>();
            //String a = "a";
            //String b = "b";
            //Strings.Add(a);
            //Strings.Add(b);
            //int d = 2;
            //int g = 5;
            //ArrayList al = new ArrayList();
            //al.Add(Strings);
            //al.Add(a);
            //al.Add(b);
            //al.Add(d);
            //al.Add(g);

            //DOM DOM = new DOM();
            //DOM.CreateModel(String.Empty);
            //Element1.Add(/*new WBCore.DOM.Attribute("", AttributeType.None)*/);
            //  Console.WriteLine(DOM.ToString());

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

            //Del handler = DelegateMethod;
            //handler("hello world"); 
            //MethodWithCallback(1, 2, handler);
            //handler = DelegateMethodReverse;
            //handler("hello world");       
            //MethodWithCallback(1, 2, handler);
            //ABC ac = null;//= new ABC(3);
            //Console.WriteLine(AppendChild(ac));
            ABC  abc = new ABC();
            Console.WriteLine(abc.tostr());
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
      
    }
    public class ABC:C
    {
       
        public ABC()
        {
            a = "A";
            b = "B";
            c = "C";
        }
        public override string tostr()
        {
            return base.tostr();
        }
        


    }
    public abstract class A
    {
        public string a { get; set; }
        public A()
        {  }
        public virtual string tostr() { return a; }
    }
    public abstract class B : A
    {
        public string b { get; set; }
        public B() { }

        public override string tostr()
        {
            return base.tostr() + b; ;
        }
    }
    public abstract class C : B
    {
        public string c { get; set; }
        public C() {  }
        public override string tostr()
        {
            return base.tostr() + c;
        }
    }




}