using System;
using System.Collections;

namespace WBCore.Dom
{
    public abstract class INode //: IDOMNode
    {
        protected INode()
        {
            NodeName = "Node";
            NodeValue = String.Empty;
            TextContent = String.Empty;
            ChildNodes = new ArrayList();
        }

        protected INode(string value)
        {
            NodeName = "Node";
            TextContent = String.Empty;
            NodeValue = value;
            ChildNodes = new ArrayList();
        }
        
        public INode FirstChild
        {
            get
            {
                return ChildNodes[0] as INode;
            }
        }

        public INode LastChild
        {
            get
            {
                return ChildNodes[ChildNodes.Count] as INode;
            }
        }

        public INode PreviousSibling { get; set; }

        public INode NextSibling { get; set; }

        public NodeType NodeType { get; set; }

        public string NodeName { get; set; }

        public string NodeValue { get; set; }

        public string TextContent { get; set; }
        
        public ArrayList ChildNodes { get; }
      
        public INode ParentNode { get; set; }

        public bool HasChildNodes
        {
            get
            {
                return (ChildNodes.Count > 0) ? true : false;
            }
        }
        //public Document ownerDocument { get; set; }
        //public Element ParentElement { get; set; }
        public void AppendChild(INode node)
        {
            ChildNodes.Add(node);
        }

        public void RemoveChild(INode node)
        {
            ChildNodes.Remove(node);
        }

        public void Insert(INode node, int index)
        {
            ChildNodes.Insert(index, node);
        }

        public bool Contains(INode node)
        {
            return ChildNodes.Contains(node);
        }

        public bool IsEqual(INode node)
        {
            return (node == this) ? true : false;
        }    
        /*GetSiblings*/
        //void normalize();

        //      [NewObject]
        //      Node cloneNode(optional boolean deep = false);

        //const unsigned short DOCUMENT_POSITION_DISCONNECTED = 0x01;
        //const unsigned short DOCUMENT_POSITION_PRECEDING = 0x02;
        //const unsigned short DOCUMENT_POSITION_FOLLOWING = 0x04;
        //const unsigned short DOCUMENT_POSITION_CONTAINS = 0x08;
        //const unsigned short DOCUMENT_POSITION_CONTAINED_BY = 0x10;
        //const unsigned short DOCUMENT_POSITION_IMPLEMENTATION_SPECIFIC = 0x20;
        //      short compareDocumentPosition(Node other);
        //      DOMString? lookupPrefix(DOMString? namespace);
        //DOMString? lookupNamespaceURI(DOMString? prefix);
        //  boolean isDefaultNamespace(DOMString? namespace);
        //  Node replaceChild(Node node, Node child);
     
        //  }
        //  }
    }
}