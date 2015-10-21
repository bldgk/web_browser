namespace WBCore.DOM.HTMLElements
{
    public class HTMLTitleElement : HTMLElement
    {
        public HTMLTitleElement() : base()
        {
        }

        public HTMLTitleElement(string text) : base()
        {
            Text = text;
        }

        public string Text { get; set; }
                
    }
}
