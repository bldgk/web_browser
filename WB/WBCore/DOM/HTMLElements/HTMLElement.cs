namespace WBCore.DOM.HTMLElements
{
    public abstract class HTMLElement : Element
    {
        public HTMLElement() : base()
        {
        }

        public string Title { get; set; }

        public string Lang { get; set; }

        public string Dir { get; set; }
    }
}