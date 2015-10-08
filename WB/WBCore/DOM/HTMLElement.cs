using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKit.Interop;

namespace WBCore.DOM
{
    public class HTMLElement : Element, IHTMLElement
    {
        private IDOMElement iElement;

        protected HTMLElement(IDOMElement Element)
            : base(Element)
        {
            iElement = Element;
        }

    }
}