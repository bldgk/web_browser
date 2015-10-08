using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBCore.DOM;
using WebKit.Interop;


namespace WBCore.DOM
{
    public interface INode : IDOMNode
    {

        ///*internal    */
        //internal static Node Create(IDOMNode Node)
        //{
        //    if (Node is IDOMDocument)
        //        return Document.Create(Node as IDOMDocument);
        //    else if (Node is IDOMAttr)
        //        return Attr.Create(Node as IDOMAttr);
        //    else if (Node is IDOMCharacterData)
        //        return CharacterData.Create(Node as IDOMCharacterData);
        //    else if (Node is IDOMElement)
        //        return Element.Create(Node as IDOMElement);
        //    else if (Node is IDOMDocumentType)
        //        return DocumentType.Create(Node as IDOMDocumentType);
        //    //else if (Node is IDOMDocumentFragment)
        //    //    return DocumentFragment.Create(Node as IDOMDocumentFragment);
        //    else if (Node is IDOMEntityReference)
        //        return EntityReference.Create(Node as IDOMEntityReference);
        //    //else if (Node is IDOMProcessingInstruction)
        //    //    return ProcessingInstruction.Create(Node as IDOMProcessingInstruction);
        //    else
        //        return new Node(Node);
        //}







        //    string NodeMember();

        //    string NodeValue();

        //    void SetNodeValue(string value);

        //    NodeType NodeType();

        //    INode ParentNode();

        //    INodeList ChildNodes();

        //INode FirstChild();

        //INode LastChild();

        //INode PreviousSibling();

        //INode NextSibling();

        //INodeMap Attributes();

        //    IDocument OwnerDocument();

        //INode insertBefore(INode newChild, INode refChild);

        //INode replaceChild(INode newChild, INode oldChild);
        //INode removeChild(INode oldChild);

        //INode appendChild(INode oldChild);

        //    int HasChildNodes();

        //INode CloneNode(int deep);

        //    void Normalize();

        //    int IsSupported(string feature, string version);

        //    string NamespaceURI();

        //    string Prefix();

        //    void SetPrefix(string prefix);

        //    string LocalName();

        //    int HasAttributes();
        //    int IsSameNode(INode other);

        //    int IsEqualNode(INode other);

        //    string TextContent();

        //    void SetTextContent(string text);
    }
}
