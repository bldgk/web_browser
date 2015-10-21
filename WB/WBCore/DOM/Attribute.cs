using System;
using System.Collections;

namespace WBCore.DOM
{
    /// <summary>
    /// Class Attribute
    /// </summary>
    public class Attribute : Node
    {
        public Attribute() : base()
        {
            NodeType = NodeType.Attribute;
        }

        public Attribute(string value, AttributeType type) 
            : base(value)
        {
            NodeType = NodeType.Attribute;
            Type = type;
        }

        private AttributeType Type { get; set; }

        public override void Add(Node node)
        {
            throw new NotImplementedException();
        }

        public override Node GetChild(int index)
        {
            throw new NotImplementedException();
        }

        public override ArrayList GetChildren()
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

        public override string OperationToString()
        {
            throw new NotImplementedException();
        }

        public override void Remove(Node node)
        {
            throw new NotImplementedException();
        }
    }
}
