using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKit.Interop;

namespace WBCore.DOM
{
    public class Attr : Node
    {         private IDOMAttr iAttribute;

        protected Attr(IDOMAttr Attr)
            :base(Attr)
        {
            iAttribute = Attr;
        }

        internal static Attr Create(IDOMAttr iDOMAttr) =>
            new Attr(iDOMAttr);

        public bool Specified
        {
            get
            {
                return iAttribute.specified() > 0;
            }
        }
    }
}
