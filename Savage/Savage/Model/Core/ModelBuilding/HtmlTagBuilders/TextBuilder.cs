using Savage.Core.SourceCodeModeling.Structure;
using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Savage.Core.ModelBuilding.Builders
{
	public class TextBuilder : ITagBuilder
    {
		Text TextTag
		{
			get;
			set;
		}
		public void Build(Object buildingElement, ref Grid buildingSpace)
		{
			TextTag = buildingElement as Text;
			var control = new TextBox();
			control.Text = TextTag.Value;
			control.TextWrapping = TextWrapping.Wrap;
			control.AcceptsReturn = true;
			Grid.SetRow(control, (buildingSpace as Grid).RowDefinitions.Count);
			buildingSpace.Children.Add(control);
			(buildingSpace as Grid).RowDefinitions.Add(new RowDefinition());
		}
	}
	public class TextShape : Shape
	{
		public string Text
		{
			get; set;
		}
		public float X
		{
			get; set;
		}
		public float Y
		{
			get; set;
		}
		public Color TextColor
		{
			get; set;
		}
		public float TextHeight
		{
			get; set;
		}

		protected override Geometry DefiningGeometry
		{
			get
			{
				return Geometry.Empty;
			}
		}
		protected override void OnRender(DrawingContext drawingContext)
		{
			FormattedText ft = new FormattedText(Text, new CultureInfo("ru-ru"), FlowDirection.LeftToRight,
			   new Typeface(new FontFamily("Arial"), FontStyles.Normal,
			   FontWeights.Bold, new FontStretch()), TextHeight,
			   new SolidColorBrush(TextColor));
			drawingContext.DrawText(ft, new Point(X, Y));
			//base.OnRender(drawingContext);
		}
	}
}
