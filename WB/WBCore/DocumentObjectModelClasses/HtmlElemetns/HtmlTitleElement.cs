namespace WBCore.DocumentObjectModelClasses.HtmlElements
{
    public class HtmlTitleElement : HtmlElement
    {
        public HtmlTitleElement() : base()
        {
        }

        public HtmlTitleElement(string text) : base()
        {
            Text = text;
        }

        public string Text { get; set; }
                
    }
}
