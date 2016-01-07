using Savage.Core.SourceCodeModeling.Structure.HtmlTags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Savage.Core.ModelBuilding.Builders
{
	public class TitleBuilder : ITagBuilder
    {
		Title TitleTag
		{
			get;
			set;
		}
        public void Build(object titletag, ref Grid control)
        {
			TitleTag = titletag as Title;
        }
    }
}
