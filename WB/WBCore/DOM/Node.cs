using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKit.Interop;

namespace WBCore.DOM
{
    public class Node: INode
    {
        private INode iNode { get; set; }
        
        public Node(INode Node)
        {
            iNode = Node;
        }
        public Node(IDOMNode Node)
        {
            iNode = Node as INode;
        }
        /*internal    */
        internal static Node Create(INode Node)
        {
           
                return new Node(Node);
        }

        internal static Node Create(IDOMNode Node)
        {
            
                return new Node(Node);
        }
        //public Uri NamespaceURI
        //{
        //    get
        //    {
        //        Uri NameSpaceURI;
        //        Uri.TryCreate(DOMNode.namespaceURI(), UriKind.RelativeOrAbsolute, out NameSpaceURI);
        //        return NameSpaceURI;
        //    }
        //}
        //public Document OwnerDocument
        //{
        //    get
        //    {
        //        return Document.Create(DOMNode.ownerDocument());

        //    }
        //}
        //public Node FirstChild
        //{
        //    get
        //    {
        //        return Create(DOMNode.firstChild());
        //    }
        //}

        //public Node LastChild
        //{
        //    get
        //    {
        //        return Create(DOMNode.lastChild());
        //    }
        //}

        //public string LocalName
        //{
        //    get
        //    {
        //        return DOMNode.localName();
        //    }
        //}

        //public Node NextSibling
        //{
        //    get
        //    {
        //        return Create(DOMNode.nextSibling());
        //    }
        //}

        //public string NodeName
        //{
        //    get
        //    {
        //        return DOMNode.nodeName();
        //    }
        //}

        //public NodeType NodeType
        //{
        //    get
        //    {
        //        return (NodeType)DOMNode.nodeType();
        //    }
        //}

        //public string NodeValue
        //{
        //    get
        //    {
        //        return DOMNode.nodeValue();
        //    }
        //}

        //public Node ParentNode
        //{
        //    get
        //    {
        //        return Create(DOMNode.parentNode());
        //    }
        //}

        //public string Prefix
        //{
        //    get
        //    {
        //        return DOMNode.prefix();
        //    }
        //    set
        //    {
        //        DOMNode.setPrefix(value);
        //    }
        //}

        //public Node PreviuosSubling
        //{
        //    get
        //    {
        //        return Create(DOMNode.previousSibling());
        //    }
        //}

        //public string TextContent
        //{
        //    get
        //    {
        //        return DOMNode.textContent();
        //    }
        //    set
        //    {
        //        DOMNode.setTextContent(value);
        //    }
        //}

        //public bool HasChildNotes
        //{
        //    get
        //    {
        //        return DOMNode.hasChildNodes() != 0;
        //    }
        //}

        //public bool HasAttributes
        //{
        //    get
        //    {
        //        return DOMNode.hasAttributes() != 0;
        //    }
        //}

        //public Node CloneNode(bool Deep) =>
        //    Create(DOMNode.cloneNode(Deep ? 1 : 0));

        //public Node AppendChild(Node NewChild) =>
        //    Create(DOMNode.appendChild(NewChild?.DOMNode));

        //public Node InsertBefore(Node NewChid, Node RefChild) =>
        //    Create(DOMNode.insertBefore(NewChid?.DOMNode, RefChild?.DOMNode));

        //public Node RemoveChild(Node OldChild) =>
        //    Create(DOMNode.removeChild(OldChild?.DOMNode));

        //public Node ReplaceChild(Node NewChild, Node OldChild) =>
        //    Create(DOMNode.replaceChild(NewChild?.DOMNode, OldChild?.DOMNode));

        //public NodeList ChildNodes
        //{
        //    get
        //    {
        //        return NodeList.Create(DOMNode.childNodes());
        //    }
        //}
        //public bool IsSameNode(Node Node) =>
        //    DOMNode.isSameNode((IDOMNode)Node.GetNodeObject()) > 0;

        public object GetNodeObject() =>
            iNode;

        //public bool IsEqualNode(Node Node) =>
        //    DOMNode.isEqualNode((IDOMNode)Node.GetNodeObject()) > 0;

        //public bool IsSupported(string Feature, string Version) =>
        //    DOMNode.isSupported(Feature, Version) > 0;




        public int throwException(string exceptionMessage)
        {
            return iNode.throwException(exceptionMessage);
        }

        public dynamic callWebScriptMethod(string name, ref object args, int cArgs)
        {
            return this.iNode.callWebScriptMethod(name, ref args, cArgs);
        }

        public dynamic evaluateWebScript(string script)
        {
            return this.iNode.evaluateWebScript(script);
        }

        public void removeWebScriptKey(string name)
        {
            iNode.removeWebScriptKey(name);
        }

        public string stringRepresentation()
        {
            return iNode.stringRepresentation();
        }

        public dynamic webScriptValueAtIndex(uint index)
        {
            return this.iNode.webScriptValueAtIndex(index);
        }

        public void setWebScriptValueAtIndex(uint index, object val)
        {
            iNode.setWebScriptValueAtIndex(index, val);
        }

        public void setException(string description)
        {
            iNode.setException(description);
        }



        public string nodeName()
        {
            return iNode.nodeName();
        }

        public string nodeValue()
        {
            return iNode.nodeValue();
        }

        public void setNodeValue(string value)
        {
            iNode.setNodeValue(value);
        }

        public ushort nodeType()
        {
            return iNode.nodeType();
        }

        public IDOMNode parentNode()
        {
            return iNode.parentNode();
        }

        public IDOMNodeList childNodes()
        {
            return iNode.childNodes();
        }

        public IDOMNode firstChild()
        {
            return iNode.firstChild();
        }

        public IDOMNode lastChild()
        {
            return iNode.lastChild();
        }

        public IDOMNode previousSibling()
        {
            return iNode.previousSibling();
        }

        public IDOMNode nextSibling()
        {
            return iNode.nextSibling();
        }

        public IDOMNamedNodeMap attributes()
        {
            return iNode.attributes();
        }

        public IDOMDocument ownerDocument()
        {
            return iNode.ownerDocument();
        }

        public IDOMNode insertBefore(IDOMNode newChild, IDOMNode refChild)
        {
            return iNode.insertBefore(newChild, refChild);
        }

        public IDOMNode replaceChild(IDOMNode newChild, IDOMNode oldChild)
        {
            return iNode.replaceChild(newChild, oldChild);
        }

        public IDOMNode removeChild(IDOMNode oldChild)
        {
            return iNode.removeChild(oldChild);
        }

        public IDOMNode appendChild(IDOMNode oldChild)
        {
            return iNode.appendChild(oldChild);
        }

        public int hasChildNodes()
        {
            return iNode.hasChildNodes();
        }

        public IDOMNode cloneNode(int deep)
        {
            return iNode.cloneNode(deep);
        }

        public void normalize()
        {
            iNode.normalize();
        }

        public int isSupported(string feature, string version)
        {
            return iNode.isSupported(feature, version);
        }

        public string namespaceURI()
        {
            return iNode.namespaceURI();
        }

        public string prefix()
        {
            return iNode.prefix();
        }

        public void setPrefix(string prefix)
        {
            iNode.setPrefix(prefix);
        }

        public string localName()
        {
            return iNode.localName();
        }

        public int hasAttributes()
        {
            return iNode.hasAttributes();
        }

        public int isSameNode(IDOMNode other)
        {
            return iNode.isSameNode(other);
        }

        public int isEqualNode(IDOMNode other)
        {
            return iNode.isEqualNode(other);
        }

        public string textContent()
        {
            return iNode.textContent();
        }

        public void setTextContent(string text)
        {
            iNode.setTextContent(text);
        }
    }
    public class NodeList : IEnumerable<Node>
    {
        private IDOMNodeList iNodeList;

        public int Length
        {
            get
            {
                return (int)iNodeList.length();
            }
        }

        protected NodeList(IDOMNodeList NodeList)
        {
            iNodeList = NodeList;
        }

        internal static NodeList Create(IDOMNodeList NodeList) =>
            new NodeList(NodeList);

        public Node this[int index]
        {
            get
            {
                if (index < 0 || index >= (int)iNodeList.length())
                    throw new IndexOutOfRangeException();
                return Node.Create(iNodeList.item((uint)index));
            }
        }

        public Node GetItem(int index) =>
            this[index];

        public IEnumerator<Node> GetEnumerator()
        {
            for (uint i = 0; i < iNodeList.length(); ++i)
                yield return Node.Create(iNodeList.item(i));
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (IElement Node in this)
                yield return Node;
        }
    }
}