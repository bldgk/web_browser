namespace WBCore.DOM.HTMLElements
{
    public class HTMLParagraphElement : HTMLElement
    {
        public HTMLParagraphElement() : base()
        {
        }

        public HTMLParagraphElement(string paragraphText)
            : base()
        {
            Text = paragraphText;
        }

        public string Align { get; set; }

        public string Text { get; set; }
    }
}