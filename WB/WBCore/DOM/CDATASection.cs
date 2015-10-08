using System;
using WebKit.Interop;

namespace WBCore.DOM
{
    public class CDATASection:Text
    {
        IDOMCDATASection DOMCDATASection;
        protected CDATASection(IDOMCDATASection CDATASection)
            : base(CDATASection)
        {
            DOMCDATASection = CDATASection;
        }

        internal static CDATASection Create(IDOMCDATASection iDOMCDATASection) =>
            new CDATASection(iDOMCDATASection);
    }
}