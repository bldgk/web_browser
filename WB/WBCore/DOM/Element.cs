namespace WBCore.Dom
{
    public abstract class Element : INode
    {
        protected Element() : base()
        {
            NodeType = NodeType.Element;
        }

        public System.Uri NamespaceUri { get; set; }

        public string Prefix { get; set; }

        public string LocalName { get; set; }

        public string TagName { get; set; }

        public string Id { get; set; }

        public string ClassName { get; set; }

        //  DOMTokenList classList;
        //    NamedNodeMap  s;
        //string GetAttribute(string name)
        //{ return String.Empty; }
        //string GetAttributeNS(string Namespace, string localName)
        //{ return String.Empty; }
        //void SetAttribute(string name, string value)
        //{ }
        //void SetAttributeNS(string Namespace, string name, string value) { }
        //void RemoveAttribute(string name) { }
        //void RemoveAttributeNS(string Namespace, string localName) { }
        //bool HasAttribute(string name) { return true; }
        //bool HasAttributeNS(string Namespace, string localName) { return true; }
        //HTMLCollection getElementsByTagName(string localName);
        //  HTMLCollection getElementsByTagNameNS(string namespace, string localName);
        //HTMLCollection getElementsByClassName(string classNames)
    }
}