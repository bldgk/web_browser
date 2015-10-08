using System;
using WebKit.Interop;

namespace WBCore.DOM
{
    public class DocumentImplementation
    {
        private IDOMImplementation DOMDocumentImplementation;

         protected DocumentImplementation(IDOMImplementation Implementation)
        {
            DOMDocumentImplementation = Implementation;
        }

        internal static DocumentImplementation Create(IDOMImplementation Implementation)=>
             new DocumentImplementation(Implementation);
       
          public Document CreateDocument(string NamespaceURI, string QualifiedName, DocumentType DocType)
        {
            return Document.Create(DOMDocumentImplementation.createDocument(NamespaceURI, QualifiedName, (IDOMDocumentType)DocType.GetNodeObject()));
        }

       public DocumentType CreateDocumentType(string QualifiedName, string PublicID, string SystemID)
        {
            return DocumentType.Create(DOMDocumentImplementation.createDocumentType(QualifiedName, PublicID, SystemID));
        }

          public bool HasFeature(string Feature, string Version)
        {
            return DOMDocumentImplementation.hasFeature(Feature, Version) > 0;
        }
    }
}