using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WebBrowserConrolProject.ModelBuilding.HtmlBuilders
{
	public class HeadBuilder : ITagBuilder
    {
        public void Build()
        {
            Console.WriteLine(GetType().Name);
        }
    }
}
