using System;
using WebKit.Interop;

namespace WBCore.DOM
{
    public class DocumentFragment : IElement
    {
        private IDOMDocumentFragment DOMDocumentFragment;

        protected DocumentFragment(IDOMDocumentFragment DocumentFragment)
            : base(DocumentFragment)
        {
            DOMDocumentFragment = DocumentFragment;
        }

        internal static DocumentFragment Create(IDOMDocumentFragment DocumentFragment) =>
             new DocumentFragment(DocumentFragment);
    }
}