using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKit.Interop;

namespace WBCore.DOM
{
    public class HTMLElement : Element 
    {
        private IElement iElement;

        protected HTMLElement(IElement Element)
        {
            IElement = Element;
        }

        internal static Element Create(IElement Element)
        {
            return new HTMLElement(IElement);
        }

        public NodeMap Attributes
        {
            get
            {
                return NodeMap.Create(iElement.attributes());
            }
        }

        public string TagName
        {
            get
            {
                return iElement.tagName();
            }
        }

        public string GetAttribute(string Name) =>
            iElement.getAttribute(Name);

        public string GetAttributeNamespace(string NamespaceURI, string LocalName) =>
             iElement.getAttributeNS(NamespaceURI, LocalName);

        public Attr GetAttributeNode(string Name) =>
            Attr.Create(iElement.getAttributeNode(Name));

        public Attr GetAttributeNodeNamespace(string NamespaceURI, string LocalName) =>
            Attr.Create(iElement.getAttributeNodeNS(NamespaceURI, LocalName));

        public bool HasAttribute(string Name) =>
            iElement.hasAttribute(Name) > 0;

        public bool HasAttributeNS(string NamespaceURI, string LocalName) =>
                iElement.hasAttributeNS(NamespaceURI, LocalName) > 0;

        public void RemoveAttribute(string Name) =>
            iElement.removeAttribute(Name);

        public void RemoveAttributeNS(string NamespaceURI, string LocalName) =>
        iElement.removeAttributeNS(NamespaceURI, LocalName);

        public Attr RemoveAttributeNode(Attr OldAttr) =>
            Attr.Create(iElement.removeAttributeNode((IDOMAttr)OldAttr.GetNodeObject()));

        public void SetAttribute(string Name, string Value) =>
            iElement.setAttribute(Name, Value);

        public void SetAttributeNS(string NamespaceURI, string QualifiedName, string Value) =>
            iElement.setAttributeNS(NamespaceURI, QualifiedName, Value);

        public Attr SetAttributeNode(Attr NewAttr) =>
        Attr.Create(iElement.setAttributeNode((IDOMAttr)NewAttr.GetNodeObject()));

        public Attr SetAttributeNodeNamespace(Attr NewAttr) =>
         Attr.Create(iElement.setAttributeNodeNS((IDOMAttr)NewAttr.GetNodeObject()));

        /// <summary>
        /// Sets input focus to this element.
        /// </summary>
        public void Focus() =>
        iElement.focus();

        /// <summary>
        /// Removes input focus from this element.
        /// </summary>
        public void Blur() =>
            iElement.blur();
    }
}
