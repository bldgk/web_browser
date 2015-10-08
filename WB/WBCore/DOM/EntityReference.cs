using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKit.Interop;

namespace WBCore.DOM
{
    public class EntityReference : IElement
    {
        private IDOMEntityReference DOMEntityReference;

        protected EntityReference(IDOMEntityReference EntityReference)
            : base(EntityReference)
        {
            DOMEntityReference = EntityReference;
        }

        internal static EntityReference Create(IDOMEntityReference EntityReference)
        {
            return new EntityReference(EntityReference);
        }
    }
}
