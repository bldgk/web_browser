using Savage.Core.SourceCodeModeling.Structure.HtmlTags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Savage.Core.ModelBuilding.Builders
{
	public class HeadBuilder : ITagBuilder
    {
		Head HeadTag
		{
			get;
			set;
		}
        public void Build(object headtag, ref Grid control)
        {
			HeadTag = headtag as Head;
        }
    }
}
