using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKit.Interop;

namespace WBCore.DOM
{
    public class Document : Node, IDocument
    {
        private IDOMDocument DOMDocument;

        protected Document(IDOMDocument Document)
            : base(Document)
        {
            DOMDocument = Document;
        }

        internal static Document Create(IDOMDocument iDOMDocument) =>
            new Document(iDOMDocument);

        public DocumentType DocumentType
        {
            get
            {
                return DocumentType.Create(DOMDocument.doctype());
            }
        }

        public DocumentImplementation Implementation
        {
            get
            {
                return DocumentImplementation.Create(DOMDocument.implementation());
            }
        }

        public Attr CreateAttribute(string Name) =>
            Attr.Create(DOMDocument.createAttribute(Name));

        public Attr CreateAttrubuteNamespace(string NamespaceURI, string Name) =>
            Attr.Create(DOMDocument.createAttributeNS(NamespaceURI, Name));

        public Comment CreateComment(string Data) =>
            Comment.Create(DOMDocument.createComment(Data));

        public CDATASection CreateCDATASection(string Data) =>
            CDATASection.Create(DOMDocument.createCDATASection(Data));

        public DocumentFragment CreateDocumentFragment() =>
            DocumentFragment.Create(DOMDocument.createDocumentFragment());

        public Text CreateTextNode(string Data) =>
            Text.Create(DOMDocument.createTextNode(Data));

        public Element CreateElement(string TagName) =>
            Create(DOMDocument.createElement(TagName)) as Element;

        public Element CreateElementNamespace(string NamespaceURI, string TagName) =>
            Create(DOMDocument.createElementNS(NamespaceURI, TagName)) as Element; 

        public EntityReference CreateEntityReference(string Name) =>
            EntityReference.Create(DOMDocument.createEntityReference(Name));

        public ProcessingInstruction CreateProcessingInstruction(string Target, string Data) =>
            ProcessingInstruction.Create(DOMDocument.createProcessingInstruction(Target, Data));

        public Element GetElementById(string Id) =>
            Create(DOMDocument.getElementById(Id)) as Element;

        public NodeList GetElementsByTagName(string TagName) =>
            NodeList.Create(DOMDocument.getElementsByTagName(TagName));

        public NodeList GetElementsByTagNameNamespace(string NamespaceURI, string TagName) =>
            NodeList.Create(DOMDocument.getElementsByTagNameNS(NamespaceURI, TagName));

        public Node ImportNode(Node NodeToImport, bool Deep) =>
            Create(DOMDocument.importNode((IDOMNode)NodeToImport.GetNodeObject(), Deep ? 1 : 0));

        public object InvokeScriptMethod(string Method, params object[] args)
        {
            object o = args;
            return DOMDocument.callWebScriptMethod(Method, ref o, args.Length);
        }
    }
}