using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKit.Interop;

namespace WBCore.DOM
{
    public class Element : Node, IElement
    {
        private IDOMElement iDOMElement;
        private IElement iElement;
        protected Element(IDOMElement Element)
            :base(Element)
        { 
            iDOMElement = Element;
        }
        protected Element(IElement Element)
        :base(Element)
        {
            iElement = Element;
        }
        internal static Element Create(IElement Element)
        {

            return new Element(Element);
        }

        public NodeMap Attributes
        {
            get
            {
                return NodeMap.Create(iDOMElement.attributes());
            }
        }

        public string TagName
        {
            get
            {
                return iDOMElement.tagName();
            }
        }

        public string GetAttribute(string Name) =>
            iDOMElement.getAttribute(Name);

        public string GetAttributeNamespace(string NamespaceURI, string LocalName) =>
             iDOMElement.getAttributeNS(NamespaceURI, LocalName);

        public Attr GetAttributeNode(string Name) =>
            Attr.Create(iDOMElement.getAttributeNode(Name));

        public Attr GetAttributeNodeNamespace(string NamespaceURI, string LocalName) =>
            Attr.Create(iDOMElement.getAttributeNodeNS(NamespaceURI, LocalName));

        public bool HasAttribute(string Name) =>
            iDOMElement.hasAttribute(Name) > 0;

        public bool HasAttributeNS(string NamespaceURI, string LocalName) =>
                iDOMElement.hasAttributeNS(NamespaceURI, LocalName) > 0;

        public void RemoveAttribute(string Name) =>
            iDOMElement.removeAttribute(Name);

        public void RemoveAttributeNS(string NamespaceURI, string LocalName) =>
        iDOMElement.removeAttributeNS(NamespaceURI, LocalName);

        public Attr RemoveAttributeNode(Attr OldAttr) =>
            Attr.Create(iDOMElement.removeAttributeNode((IDOMAttr)OldAttr.GetNodeObject()));

        public void SetAttribute(string Name, string Value) =>
            iDOMElement.setAttribute(Name, Value);

        public void SetAttributeNS(string NamespaceURI, string QualifiedName, string Value) =>
            iDOMElement.setAttributeNS(NamespaceURI, QualifiedName, Value);

        public Attr SetAttributeNode(Attr NewAttr) =>
        Attr.Create(iDOMElement.setAttributeNode((IDOMAttr)NewAttr.GetNodeObject()));

        public Attr SetAttributeNodeNamespace(Attr NewAttr) =>
         Attr.Create(iDOMElement.setAttributeNodeNS((IDOMAttr)NewAttr.GetNodeObject()));

        /// <summary>
        /// Sets input focus to this element.
        /// </summary>
        public void Focus() =>
        iDOMElement.focus();

        /// <summary>
        /// Removes input focus from this element.
        /// </summary>
        public void Blur() =>
            iDOMElement.blur();

        public Element Create(IElement Element)
        {
            return new Element(Element);
        }
    }
}