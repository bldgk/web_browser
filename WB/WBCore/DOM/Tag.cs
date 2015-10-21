using System.Collections;

namespace WBCore.DOM
{
    public class Tag : Node//, IDocument
    {
        public Tag() : base()
        {
        }

        public Tag(TagType type, string value) : base(value)
        {
            NodeType = NodeType.Tag;
            Type = type;
        }
        //public ArrayList TagChildren = new ArrayList();        
        public string ModelToString { get; set; }

        public TagType Type { get; set; }

        public override void Add(Node node)
        {
            Children.Add(node);
        }

        public override void Remove(Node node)
        {
            Children.Remove(node);
        }

        public override Node GetChild(int index)
        {
            return Children[index] as Node;
        }

        public override ArrayList GetChildren()
        {
            return Children;
        }      

        public override string OperationToString()
        {
            ModelToString += ToString();
            foreach (Node node in Children)
            {
                ModelToString += OperationToString();
            }
            return ModelToString;
        }

        public override string OpenTag()
        {
            return "<" + Type.ToString() + ">";
        }

        public override string CloseTag()
        {
            return "</" + Type.ToString() + ">";
        }

        public override string ToString()
        {
            return OpenTag() + base.Value + CloseTag() + "\n";
        }
        //protected Document(IDOMDocument Document)
        //    : base(Document)
        //{
        //    DOMDocument = Document;
        //}

        //internal static Document Create(IDOMDocument iDOMDocument) =>
        //    new Document(iDOMDocument);

        //public DocumentType DocumentType
        //{
        //    get
        //    {
        //        return DocumentType.Create(DOMDocument.doctype());
        //    }
        //}

        //public DocumentImplementation Implementation
        //{
        //    get
        //    {
        //        return DocumentImplementation.Create(DOMDocument.implementation());
        //    }
        //}

        //public Attr CreateAttribute(string Name) =>
        //    Attr.Create(DOMDocument.createAttribute(Name));

        //public Attr CreateAttrubuteNamespace(string NamespaceURI, string Name) =>
        //    Attr.Create(DOMDocument.createAttributeNS(NamespaceURI, Name));

        //public Comment CreateComment(string Data) =>
        //    Comment.Create(DOMDocument.createComment(Data));

        //public CDATASection CreateCDATASection(string Data) =>
        //    CDATASection.Create(DOMDocument.createCDATASection(Data));

        //public DocumentFragment CreateDocumentFragment() =>
        //    DocumentFragment.Create(DOMDocument.createDocumentFragment());

        //public Text CreateTextNode(string Data) =>
        //    Text.Create(DOMDocument.createTextNode(Data));

        //public Element CreateElement(string TagName) =>
        //    Create(DOMDocument.createElement(TagName)) as Element;

        //public Element CreateElementNamespace(string NamespaceURI, string TagName) =>
        //    Create(DOMDocument.createElementNS(NamespaceURI, TagName)) as Element; 

        //public EntityReference CreateEntityReference(string Name) =>
        //    EntityReference.Create(DOMDocument.createEntityReference(Name));

        //public ProcessingInstruction CreateProcessingInstruction(string Target, string Data) =>
        //    ProcessingInstruction.Create(DOMDocument.createProcessingInstruction(Target, Data));

        //public Element GetElementById(string Id) =>
        //    Create(DOMDocument.getElementById(Id)) as Element;

        //public NodeList GetElementsByTagName(string TagName) =>
        //    NodeList.Create(DOMDocument.getElementsByTagName(TagName));

        //public NodeList GetElementsByTagNameNamespace(string NamespaceURI, string TagName) =>
        //    NodeList.Create(DOMDocument.getElementsByTagNameNS(NamespaceURI, TagName));

        //public Node ImportNode(Node NodeToImport, bool Deep) =>
        //    Create(DOMDocument.importNode((IDOMNode)NodeToImport.GetNodeObject(), Deep ? 1 : 0));

        //public object InvokeScriptMethod(string Method, params object[] args)
        //{
        //    object o = args;
        //    return DOMDocument.callWebScriptMethod(Method, ref o, args.Length);
        //}
    }
}