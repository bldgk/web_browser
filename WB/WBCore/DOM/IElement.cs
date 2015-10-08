using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKit.Interop;

namespace WBCore.DOM
{
    public interface IElement 
    {
        /*Element(IDOMElement Element);*/

        Element Create(IElement Element);

        string GetAttribute(string Name);

        string GetAttributeNamespace(string NamespaceURI, string LocalName);

        Attr GetAttributeNode(string Name);

        Attr GetAttributeNodeNamespace(string NamespaceURI, string LocalName);

        bool HasAttribute(string Name);

        bool HasAttributeNS(string NamespaceURI, string LocalName);

        void RemoveAttribute(string Name);

        void RemoveAttributeNS(string NamespaceURI, string LocalName);

        Attr RemoveAttributeNode(Attr OldAttr);

        void SetAttribute(string Name, string Value);

        void SetAttributeNS(string NamespaceURI, string QualifiedName, string Value);

        Attr SetAttributeNode(Attr NewAttr);

        Attr SetAttributeNodeNamespace(Attr NewAttr);

        /// <summary>
        /// Sets input focus to this element.
        /// </summary>
        void Focus();

        /// <summary>
        /// Removes input focus from this element.
        /// </summary>
        void Blur();
    }
}