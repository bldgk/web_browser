namespace WBCore.DocumentObjectModelClasses.HtmlElements
{
    public class HtmlBodyElement : HtmlElement
    {
        public HtmlBodyElement() : base()
        {
            Title = "Body";
          //  NodeName = "HTMLElement";
        }
        
        public string Background { get; set; }

        public string BGColor { get; set; }

        public string Link { get; set; }

        public string Text { get; set; }
        
    }
}