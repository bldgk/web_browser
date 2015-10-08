using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKit.Interop;

namespace WBCore.DOM
{
    class XAMLElement : Element
    {
        private IDOMElement DOMXamlElement;

        /// <summary>
        /// HTMLElement constructor.
        /// </summary>
        /// <param name="HTMLElement">WebKit IDOMHTMLElement object.</param>
        protected XAMLElement(IDOMElement XAMLElement)
            : base(XAMLElement)
        {
            DOMXamlElement = XAMLElement;
        }

        internal static XAMLElement Create(IDOMElement XAMLElement)
        {
            return new XAMLElement(XAMLElement);
        }
    }
}
