using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKit.Interop;

namespace WBCore.DOM
{
    class XAMLDocument:Document
    {
        protected XAMLDocument(IDOMDocument Document)
            : base(Document)
        { }

        public XAMLElement CreateElement(string TagName)
        {
            return new XAMLElement(base.CreateElement(TagName));
        }
    }
}
