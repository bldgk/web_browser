namespace WBCore.DOM.HTMLElements
{
    public class HTMLBodyElement : HTMLElement
    {
        public HTMLBodyElement() : base()
        {
            Title = "Body";
            NodeName = "HTMLElement";
        }
        
        public string Background { get; set; }

        public string BGColor { get; set; }

        public string Link { get; set; }

        public string Text { get; set; }
        
    }
}