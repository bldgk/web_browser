namespace WBCore.Dom
{
    public abstract class Document : INode
    {
        protected Document()
      : base()
        {
            ContentType = "text/html";
            Url = new System.Uri("about:blank");
            Encoding = "utf-8";
        }

        public System.Uri Url { get; set; }

        public string ContentType { get; set; }

        public string Encoding { get; set; }

        public DocumentType DocumentType { get; set; }

        //string origin { get; set; }
        //string compatMode { get; set; }
        //string characterSet { get; set; }
        //readonly   Element documentElement;
        //HTMLCollection getElementsByTagName(string localName);
        //      HTMLCollection getElementsByTagNameNS(string? namespace, string localName);
        //HTMLCollection getElementsByClassName(string classNames);
        //public void CreateElement(string localName)
        //    {
        //       // AppendChild();
        //    }
        //public void CreateElementNS(string Namespace, string qualifiedName)
        //    { }
        //    //public IDocumentFragment CreateDocumentFragment() { }
        //public void CreateTextNode(string data)
        //    {
        //    }        
        //public void CreateComment(string data) { }
        //public ProcessingInstruction createProcessingInstruction(string target, string data)
        //{ }
        //Node importNode(Node node, optional boolean deep = false);
        //Node adoptNode(Node node);        
        //Event createEvent(string interface);
        //Range createRange();
        // NodeFilter.SHOW_ALL = 0xFFFFFFFF
        //    NodeIterator createNodeIterator(Node root, optional unsigned long whatToShow = 0xFFFFFFFF, optional NodeFilter? filter = null) { }
        //TreeWalker createTreeWalker(Node root, optional unsigned long whatToShow = 0xFFFFFFFF, optional NodeFilter? filter = null) { }
    }
}