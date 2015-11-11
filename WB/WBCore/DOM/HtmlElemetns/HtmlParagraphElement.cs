namespace WBCore.Dom.HtmlElements
{
    public class HtmlParagraphElement : HtmlElement
    {
        public HtmlParagraphElement() : base()
        {
        }

        public HtmlParagraphElement(string paragraphText)
            : base()
        {
            Text = paragraphText;
        }

        public string Align { get; set; }

        public string Text { get; set; }
    }
}