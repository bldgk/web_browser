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
	public class DivBuilder : ITagBuilder
    {
		Div DivTag
		{
			get;
			set;
		}
		public void Build(Object buildingElement, ref Grid buildingSpace)
		{
			DivTag = buildingElement as Div;
			
			Grid Div = new Grid();
			Div.Background = new SolidColorBrush(Colors.Red);
			Grid.SetRow(Div, (buildingSpace as Grid).RowDefinitions.Count);
			buildingSpace.Children.Add(Div);
			((Grid)buildingSpace).RowDefinitions.Add(new RowDefinition());

		}
	}
}
