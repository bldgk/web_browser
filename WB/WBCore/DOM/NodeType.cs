using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBCore.DOM
{
    public enum NodeType
    {
        Element = 1,
        Attribute = 2,
        Text = 3,
        CDATASection = 4,
        EntityReference = 5,
        Entity = 6,
        ProcessingInstruction = 7,
        Comment = 8,
        Document = 9,
        DocumentType = 10
    }
}
