namespace WBCore.Dom.Html
{
    public abstract class HtmlElement : Element
    {
        protected HtmlElement() : base()
        {
        }

        public string Title { get; set; }
    }
}