using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKit.Interop;

namespace WBCore.DOM
{
    public class NodeMap : IEnumerable<IElement>
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

        public IElement this[int index]
        {
            get
            {
                if (index < 0 || index >= (int)DOMNodeMap.length())
                    return null;
                return IElement.Create(DOMNodeMap.item((uint)index));
            }
        }

        public IElement this[string name]
        {
            get
            {
                return IElement.Create(DOMNodeMap.getNamedItem(name));
            }
        }

        public IElement this[string NSURI, string localName]
        {
            get
            {
                return IElement.Create(DOMNodeMap.getNamedItemNS(NSURI, localName));
            }
        }

        public IElement GetNamedItem(string Name)
        {
            return this[Name];
        }

        public IElement GetNamedItemNamespace(string NamespaceURI, string LocalName)
        {
            return this[NamespaceURI, LocalName];
        }

        public IElement GetItem(int Index)
        {
            return this[Index];
        }

        public IElement RemoveNamedItem(string Name)
        {
            return IElement.Create(DOMNodeMap.removeNamedItem(Name));
        }

        public IElement RemoveNamedItemNamespace(string NamespaceURI, string LocalName)
        {
            return IElement.Create(DOMNodeMap.removeNamedItemNS(NamespaceURI, LocalName));
        }

        public IElement SetNamedItem(IElement Node)
        {
            return IElement.Create(DOMNodeMap.setNamedItem((IDOMNode)Node.GetNodeObject()));
        }

        public IElement SetNamedItemNamespace(IElement Node)
        {
            return IElement.Create(DOMNodeMap.setNamedItemNS((IDOMNode)Node.GetNodeObject()));
        }

        public IEnumerator<IElement> GetEnumerator()
        {
            for (uint i = 0; i < DOMNodeMap.length(); ++i)
                yield return IElement.Create(DOMNodeMap.item(i));
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (IElement node in this)
                yield return node;
        }
    }
}