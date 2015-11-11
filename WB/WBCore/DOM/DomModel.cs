using WBCore.Dom.HtmlElements;

namespace WBCore.Dom
{
    public class DomModel
    {
        public DomModel()
        {
          //  Document = new HtmlDocument();
        }

        public INode Document { get; set; }

        public INode Model
        {
            get
            {
                return Document;
            }

        }

        public void CreateModel()
        {

            //Document.AppendChild(new DocumentType(DocType.Html));
            //INode html = new HtmlHtmlElement();
            //Document.AppendChild(html);
            //INode head = new HtmlHeadElement();
            //html.AppendChild(head);
            //INode title = new HtmlTitleElement();
            //head.AppendChild(title);
            //INode body = new HtmlBodyElement();
            //html.AppendChild(body);
            //INode p = new HtmlParagraphElement("Paragraph");
            //body.AppendChild(p);
        }
    }
}