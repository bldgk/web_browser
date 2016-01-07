using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBCore;
using WBCore.DocumentObjectModelClasses;

namespace WBLibrary
{

	public class Document
	{
		public System.Uri Url
		{
			get; set;
		} = new System.Uri("about:blank");

		public string ContentType
		{
			get; set;
		} = "text/html";

		public string Encoding
		{
			get; set;
		} = "utf-8";

		//public DocumentType DocumentType
		//{
		//	get; set;
		//}

		//    //string origin { get; set; }
		//    //string compatMode { get; set; }
		//    //string characterSet { get; set; }
		//    //readonly   Element documentElement;
		//    //HTMLCollection getElementsByTagName(string localName);
		//    //      HTMLCollection getElementsByTagNameNS(string? namespace, string localName);
		//    //HTMLCollection getElementsByClassName(string classNames);
		//    //public void CreateElement(string localName)
		//    //    {
		//    //       // AppendChild();
		//    //    }
		//    //public void CreateElementNS(string Namespace, string qualifiedName)
		//    //    { }
		//    //    //public IDocumentFragment CreateDocumentFragment() { }
		//    //public void CreateTextNode(string data)
		//    //    {
		//    //    }        
		//    //public void CreateComment(string data) { }
		//    //public ProcessingInstruction createProcessingInstruction(string target, string data)
		//    //{ }
		//    //Node importNode(Node node, optional boolean deep = false);
		//    //Node adoptNode(Node node);        
		//    //Event createEvent(string interface);
		//    //Range createRange();
		//    // NodeFilter.SHOW_ALL = 0xFFFFFFFF
		//    //    NodeIterator createNodeIterator(Node root, optional unsigned long whatToShow = 0xFFFFFFFF, optional NodeFilter? filter = null) { }
		//    //TreeWalker createTreeWalker(Node root, optional unsigned long whatToShow = 0xFFFFFFFF, optional NodeFilter? filter = null) { }
		//}
		public string SourceCode
		{
			get; private set;
		} = string.Empty;

		public DocumentObjectModel Model
		{
			get; set;
		} = new DocumentObjectModel();
		
		public Document(string srccode)
		{
			SourceCode = srccode;
			Model = Core.GetModelFromSourceCode(SourceCode);
		}


		//public IEnumerable<Tag> FindAll(string selector)
		//{
		//    SelectorParser parser = new SelectorParser();
		//    var selectorGroup = parser.Parse(selector);
		//    return selectorGroup.Apply(GetTags());
		//}

		//public Tag Find(string selector)
		//{
		//    return FindAll(selector).FirstOrDefault();
		//}

		//public T Find<T>(string selector)
		//{
		//    return FindAll<T>(selector).FirstOrDefault();
		//}

		//public IEnumerable<T> FindAll<T>(string selector)
		//{
		//    return FindAll(selector).OfType<T>();
		//}
	}
}
