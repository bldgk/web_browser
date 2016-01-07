using System;
using System.IO;
using System.Linq;
using WBCore;
using WBCore.DocumentObjectModelClasses;
using WBCore.DocumentObjectModelClasses.HtmlTags;
using WBLibrary;
namespace WBTest
{
   
    public class Program
    {
       

        public static void Main(string[] args)
        {
			string html = File.ReadAllText(@"C:\Users\kiril_000\Desktop\1.html");

			Document doc = new Document(html);// HtmlParser(.panew HtmlParser().Parse(html));
            doc.Model.Root.Print();
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}