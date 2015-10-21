using System;
using System.Collections;

namespace WBCore.Dom
{
    public class AttributeTag : Node
    {
        public AttributeTag() : base()
        {
            NodeType = NodeType.Attribute;
        }

        public AttributeTag(string value, AttributeType type)
            : base(value)
        {
            NodeType = NodeType.Attribute;
            AttributeType = type;
        }

        public AttributeType AttributeType { get; set; }

        public override void Add(Node node)
        {
            throw new NotImplementedException();
        }

        public override Node GetChild(int index)
        {
            throw new NotImplementedException();
        }

        public override string CloseTag()
        {
            throw new NotImplementedException();
        }

        public override string OpenTag()
        {
            throw new NotImplementedException();
        }

        public override void Remove(Node node)
        {
            throw new NotImplementedException();
        }
    }
}
