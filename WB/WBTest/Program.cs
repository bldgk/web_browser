using System;
using System.IO;
using System.Linq;
using WBCore;
using WBCore.DocumentObjectModelClasses;

namespace WBTest
{
   
    public class Program
    {
       

        public static void Main(string[] args)
        {
            HtmlParser hp = new HtmlParser();
            HtmlEncoder he = new HtmlEncoder();
            Document doc = hp.Parse(File.ReadAllText(@"C:\Users\kiril_000\Desktop\1.html"));
            doc.DocumentObjectModel.Root.Print();
            Console.ReadKey();
        }
    }
}