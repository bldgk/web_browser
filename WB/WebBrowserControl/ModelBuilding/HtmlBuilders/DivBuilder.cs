using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowserConrolProject.ModelBuilding.HtmlBuilders

{
	public class DivBuilder : ITagBuilder
    {
        public void Build()
        {
            Console.WriteLine(GetType().Name);
        }
    }
}
