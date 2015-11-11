namespace WBCore.Dom.HtmlElements
{
    public class HtmlImageElement : HtmlElement
    {
        public HtmlImageElement() : base()
        {
        }

        public string Name { get; set; }

        public string Align { get; set; }

        public string Alt { get; set; }

        public string Border { get; set; }

        public long Height { get; set; }

        public string Source { get; set; }

        public long Width { get; set; }
    }
}
