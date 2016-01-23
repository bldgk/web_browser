using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args) {
			//		doc.Load(@"C:\Users\kiril_000\Desktop\1.html");
			HtmlWeb client = new HtmlWeb();
			var exct = client.Load(@"http://pdd.ua/ua/");
			Console.WriteLine(exct.DocumentNode.GetType().ToString());
			var title = exct.DocumentNode.Descendants("title");
			var divs = exct.DocumentNode.Descendants().Where(d => d.Attributes.Contains("class")&&d.Attributes["class"].Value.Contains("pdd"));

            Console.ReadKey();	}
	}
}
