using System.Collections;

namespace WBCore.DOM
{
    public abstract class Node// /* Component */
    {
        private Node parent;

        public Node()
        {
            Children = new ArrayList();
            //_children = new NodeCollection(this);
            //NodesInPage.Add(this);
        }

        public Node(string value)
        {
            //_children = new NodeCollection(this);
            Value = value;
            ////NodesInPage.Add(this);
        }            

        public string Value { get; set; }

        public NodeType NodeType { get; set; }

        protected ArrayList Children { get; set; }

        public abstract void Add(Node node);
        //{
        //    var NewChildNode = new Node(name);
        //    Childrens.Add(NewChildNode);
        //    return NewChildNode;
        //}
        //public abstract void Add(string NodeName);
        public abstract void Remove(Node node);

        public abstract Node GetChild(int index);

        public abstract ArrayList GetChildren();

        public abstract string OperationToString();

        public abstract string OpenTag();

        public abstract string CloseTag();
               
        public class NodeCollection : System.Collections.ObjectModel.Collection<Node>
        {
            private Node owner;

            internal NodeCollection(Node owner)
            {
                this.owner = owner;
            }
            
            protected override void InsertItem(int index, Node item)
            {
                if (!Contains(item))
                {
                    base.InsertItem(index, item);
                    item.parent = owner;
                }
            }

            protected override void RemoveItem(int index)
            {
                this[index].parent = null;
                base.RemoveItem(index);
            }
            
        }
        //////public NodeCollection Children
        ////{
        ////    get
        ////    {
        ////        return _children;
        ////    }
        ////}

        ////public Node Parent
        ////{
        ////    get
        ////    {
        ////        return _parent;
        ////    }
        ////    set
        ////    {
        ////        if (Parent != null || value == null)
        ////        {
        ////            Parent.Children.Remove(this);
        ////        }
        ////        else
        ////        {
        ////            value.Children.Add(this);
        ////        }
        ////        _parent = value;
        ////    }
        ////}

        //////public NodeCollection Siblings
        //////{
        //////    get
        //////    {
        //////        _siblings = Parent.Children;
        //////        _siblings.Remove(this);
        //////        return _siblings;
        //////    }
        //////}

        ////public int Level
        ////{
        ////    get
        ////    {
        ////        return Parent != null ? this.Parent.Level + 1 : 0;
        ////    }
        ////}
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

        //public object GetNodeObject() =>
        //    iNode;

        //public bool IsEqualNode(Node Node) =>
        //    DOMNode.isEqualNode((IDOMNode)Node.GetNodeObject()) > 0;

        //public bool IsSupported(string Feature, string Version) =>
        //    DOMNode.isSupported(Feature, Version) > 0;
    }
}