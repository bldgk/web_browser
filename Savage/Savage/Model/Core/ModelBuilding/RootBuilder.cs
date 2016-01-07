using Savage.Core.SourceCodeModeling.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Savage.Core.ModelBuilding.Builders
{
	public class RootBuilder : ITagBuilder
    {
		Root Root
		{
			get;
			set;
		}
        public void Build(object roottag, ref Grid cotnrol)
        {
			Root = roottag as Root;
			cotnrol = new Grid();
        }
    }
}
