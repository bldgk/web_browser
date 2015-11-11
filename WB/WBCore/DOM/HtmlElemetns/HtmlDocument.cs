using System.Collections;

namespace WBCore.Dom.HtmlElements
{
    public class HtmlDocument //: Document
    {
        public HtmlDocument() : base()
        {
            //NodeName = "Document";
        }

        public string Title { get; set; }

        //string referrer { get; set; }

        //string Domain { get; set; }

        //HTMLElement body;
        //HTMLCollection  images;
        //HTMLCollection  applets;
        //HTMLCollection  links;
        //HTMLCollection  forms;
        //HTMLCollection  anchors;
        public string Cookie { get; set; }
        //// raises(DOMException) on setting

        //public ArrayList GetElementsByName(string elementName)
        //{
        //    return new ArrayList();
        //}
    }
}