using Savage.Core.SourceCodeModeling.Structure.HtmlTags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Savage.Core.ModelBuilding.Builders
{
	public class HtmlBuilder : ITagBuilder
    {
		Html HtmlTag
		{
			get;
			set;
		}
		public void Build(object htmltag, ref Grid control)
		{
			HtmlTag = htmltag as Html;
		}
    }
}
