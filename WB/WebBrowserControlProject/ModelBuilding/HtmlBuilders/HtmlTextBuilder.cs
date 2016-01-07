using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WebBrowserConrolProject.ModelBuilding.HtmlBuilders
{
	public class TextBuilder : ITagBuilder
    {
        public void Build()
        {
            
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
