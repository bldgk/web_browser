using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKit.Interop;

namespace WBCore.DOM
{
    public class NodeMap : IEnumerable<Node>
    {
        private IDOMNamedNodeMap DOMNodeMap;

        protected NodeMap(IDOMNamedNodeMap NamedNodeMap)
        {
            DOMNodeMap = NamedNodeMap;
        }

        internal static NodeMap Create(IDOMNamedNodeMap NamedNodeMap) =>
            new NodeMap(NamedNodeMap);

        public int Length
        {
            get
            {
                return (int)DOMNodeMap.length();
            }
        }

        public Node this[int index]
        {
            get
            {
                if (index < 0 || index >= (int)DOMNodeMap.length())
                    return null;
                return Node.Create(DOMNodeMap.item((uint)index));
            }
        }

        public Node this[string name]
        {
            get
            {
                return Node.Create(DOMNodeMap.getNamedItem(name));
            }
        }

        public Node this[string NSURI, string localName]
        {
            get
            {
                return Node.Create(DOMNodeMap.getNamedItemNS(NSURI, localName));
            }
        }

        public Node GetNamedItem(string Name)
        {
            return this[Name];
        }

        public Node GetNamedItemNamespace(string NamespaceURI, string LocalName)
        {
            return this[NamespaceURI, LocalName];
        }

        public Node GetItem(int Index)
        {
            return this[Index];
        }

        public Node RemoveNamedItem(string Name)
        {
            return Node.Create(DOMNodeMap.removeNamedItem(Name));
        }

        public Node RemoveNamedItemNamespace(string NamespaceURI, string LocalName)
        {
            return Node.Create(DOMNodeMap.removeNamedItemNS(NamespaceURI, LocalName));
        }

        public Node SetNamedItem(Node Node)
        {
            return Node.Create(DOMNodeMap.setNamedItem((IDOMNode)Node.GetNodeObject()));
        }

        public Node SetNamedItemNamespace(Node Node)
        {
            return Node.Create(DOMNodeMap.setNamedItemNS((IDOMNode)Node.GetNodeObject()));
        }

        public IEnumerator<Node> GetEnumerator()
        {
            for (uint i = 0; i < DOMNodeMap.length(); ++i)
                yield return Node.Create(DOMNodeMap.item(i));
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (Node node in this)
                yield return node;
        }
    }
}