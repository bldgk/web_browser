namespace WBCore.DOM
{
    public enum DocumentTypes
    {
        HTML
    }

    public class DocumentType : INode
    {
        //    private string publicId;
        //    private string systemId;
        public DocumentType(DocumentTypes documentType) : base()
        {
            NodeName = "DocumentType";
            Type = documentType;
        }

        public string Name { get; set; }

        public DocumentTypes Type { get; set; }

        //public static DocumentType None = new DocumentType(null);

        //private IDOMDocumentType DOMDocumentType;

        //public NodeMap Entities
        //{
        //    get
        //    {
        //        return NodeMap.Create(DOMDocumentType.entities());
        //    }
        //}

        //public string InternalSubset
        //{
        //    get
        //    {
        //        return DOMDocumentType.internalSubset();
        //    }
        //}

        //public string Name
        //{
        //    get
        //    {
        //        return DOMDocumentType.name();
        //    }
        //}

        //public NodeMap Notations
        //{
        //    get
        //    {
        //        return NodeMap.Create(DOMDocumentType.notations());
        //    }
        //}

        //public string PublicID
        //{
        //    get
        //    {
        //        return DOMDocumentType.publicId();
        //    }
        //}

        //public string SystemID
        //{
        //    get
        //    {
        //        return DOMDocumentType.systemId();
        //    }
        //}

        //protected DocumentType(IDOMDocumentType DocumentType)
        //    : base(DocumentType)
        //{
        //    DOMDocumentType = DocumentType;
        //}

        //internal static DocumentType Create(IDOMDocumentType DocumentType)=>
        //new DocumentType(DocumentType);
    }
}