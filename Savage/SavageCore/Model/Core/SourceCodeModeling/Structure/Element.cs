using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SavageCore.SourceCodeModeling.Structure
{
	public abstract class Element//: ITagBuilder //: INode
	{
		//protected Element() : base()
		//{
		//    NodeType = NodeType.Element;
		//}

		//public System.Uri NamespaceUri { get; set; }

		//public string Prefix { get; set; }

		//public string LocalName { get; set; }

		//public string TagName { get; set; }

		//public string Id { get; set; }

		//public string ClassName { get; set; }

		////  DOMTokenList classList;
		////    NamedNodeMap  s;
		////string GetAttribute(string name)
		////{ return String.Empty; }
		////string GetAttributeNS(string Namespace, string localName)
		////{ return String.Empty; }
		////void SetAttribute(string name, string value)
		////{ }
		////void SetAttributeNS(string Namespace, string name, string value) { }
		////void RemoveAttribute(string name) { }
		////void RemoveAttributeNS(string Namespace, string localName) { }
		////bool HasAttribute(string name) { return true; }
		////bool HasAttributeNS(string Namespace, string localName) { return true; }
		////HTMLCollection getElementsByTagName(string localName);
		////  HTMLCollection getElementsByTagNameNS(string namespace, string localName);
		////HTMLCollection getElementsByClassName(string classNamesprivate List<Element> children = new List<Element>();
		private List<Element> children = new List<Element>();

		public string ElementName { get; set; }

		public Element Parent { get; set; }

		public Element Previous { get; set; }

		public Element Next { get; set; }

		public Element NextSibling { get; set; }

		public Element PreviousSibling { get; set; }

		public ReadOnlyCollection<Element> Children { get { return children.AsReadOnly(); } }

		protected Element()
		{
			ElementName = "";
		}

		public void Setup(Element parent, Element previous)
		{
			Parent = parent;
			Previous = previous;
			if (Parent != null && Parent.children.Count > 0)
			{
				PreviousSibling = Parent.children[Parent.children.Count - 1];
				PreviousSibling.NextSibling = this;
			}
		}

		internal void AddChild(Element element)
		{

			element.Parent = this;
			Element previous = children.ElementAtOrDefault(children.Count - 1);
			if (previous != null)
			{
				element.PreviousSibling = previous;
				previous.NextSibling = element;
			}
			children.Add(element);
		}

		public string Print()
		{
			string printedText = String.Empty;
			if(this.GetType().Name == "Text")
			{
				printedText += (this as Text).Value + "\n";
			}
			foreach(Element ele in Children)
			{
				printedText += ele.Print();
			}

			return printedText;
		}
    }
}