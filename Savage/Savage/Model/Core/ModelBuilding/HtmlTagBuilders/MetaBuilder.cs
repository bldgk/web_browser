using Savage.Core.SourceCodeModeling.Structure.HtmlTags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Savage.Core.ModelBuilding.Builders
{
	public class MetaBuilder : ITagBuilder
    {
		Meta MetaTag
		{
			get;
			set;
		}
        public void Build(object metatag, ref Grid control)
        {
			MetaTag = metatag as Meta;
        }
    }
}
