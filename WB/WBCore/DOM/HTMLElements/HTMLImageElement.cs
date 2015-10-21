namespace WBCore.DOM.HTMLElements
{
    public class HTMLImageElement : HTMLElement
    {
        public HTMLImageElement() : base()
        {
        }

        public string Name { get; set; }

        public string Align { get; set; }

        public string Alt { get; set; }

        public string Border { get; set; }

        public long Height { get; set; }

        public string SRC { get; set; }

        public long Width { get; set; }
    }
}
