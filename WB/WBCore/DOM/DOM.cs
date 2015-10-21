using WBCore.DOM.HTMLElements;

namespace WBCore.DOM
{
    public class DOM
    {
        public DOM()
        {
            Document = new HTMLDocument();
        }

        public INode Document { get; set; }

        public void CreateModel(string htmlText)
        {

            Document.AppendChild(new DocumentType(DocumentTypes.HTML));
            INode html = new HTMLHtmlElement();
            Document.AppendChild(html);
            INode head = new HTMLHeadElement();
            html.AppendChild(head);
            INode title = new HTMLTitleElement("Web");
            head.AppendChild(title);
            INode body = new HTMLBodyElement();
            html.AppendChild(body);
            INode p = new HTMLParagraphElement("Paragraph");
            body.AppendChild(p);

        }

        public INode GetModel()
        {
            return Document;
        }
    }
}