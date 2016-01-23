using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace SVGCore.Modeling.Dom
{
	public class Node : IXPathNavigable
	{
		public  enum NodeTypeName
		{
			Comment = "#comment",
			Document = "#document",
			Text = "#text";
		}

		/// <summary>
		/// Gets the name of a comment node. It is actually defined as '#comment'.
		/// 
		/// </summary>
		public static readonly string HtmlNodeTypeNameComment = "#comment";
		/// <summary>
		/// Gets the name of the document node. It is actually defined as '#document'.
		/// 
		/// </summary>
		public static readonly string HtmlNodeTypeNameDocument = "#document";
		/// <summary>
		/// Gets the name of a text node. It is actually defined as '#text'.
		/// 
		/// </summary>
		public static readonly string HtmlNodeTypeNameText = "#text";

	}
}
