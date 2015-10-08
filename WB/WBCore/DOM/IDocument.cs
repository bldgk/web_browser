using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKit.Interop;

namespace WBCore.DOM
{
    interface IDocument
    {

        Attr CreateAttribute(string Name);

        Attr CreateAttrubuteNamespace(string NamespaceURI, string Name);

        Comment CreateComment(string Data);

        CDATASection CreateCDATASection(string Data);

        DocumentFragment CreateDocumentFragment();

        Text CreateTextNode(string Data);

        Element CreateElement(string TagName);

        Element CreateElementNamespace(string NamespaceURI, string TagName);
        EntityReference CreateEntityReference(string Name);

        ProcessingInstruction CreateProcessingInstruction(string Target, string Data);

        Element GetElementById(string Id);

        NodeList GetElementsByTagName(string TagName);

        NodeList GetElementsByTagNameNamespace(string NamespaceURI, string TagName);

        Node ImportNode(Node NodeToImport, bool Deep);

        object InvokeScriptMethod(string Method, params object[] args);
    }
}