using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKit.Interop;

namespace WBCore.DOM
{
   public  class HTMLDocument:Document, IHTMLDocument
    {
        private IDOMDocument iDocument;

        protected HTMLDocument(IDOMDocument Document)
            : base(Document)
        {
            iDocument = Document;
        }
        public HTMLElement CreateHTMLElement(string TagName)
        {
            return CreateElement(TagName) as HTMLElement;
        }
    }
}
