using System;
using System.Collections;
using System.Globalization;

namespace Savage.Core.SourceCodeModeling.Structure
{
    public class TagAttribute :Element
    {
        string _value;

        public string Name { get; private set; }
        public string Value
        {
            get
            {
				return _value;//.HtmlDecode();
            }
            private set
            {
                _value = value;
            }
        }
		public TagAttribute()
		{
			ElementName = "Attribute";
		}
        public TagAttribute(string name, string value)
        {
            Name = name.ToLowerInvariant();
            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                TagAttribute t = (TagAttribute)obj;
                return Name == t.Name && Value == t.Value;
            }
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Value.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}=\"{1}\"", Name, Value);
        }
        //public AttributeTag() : base()
        //{
        //    NodeType = NodeType.Attribute;
        //}

        //public AttributeTag(string value, AttributeType type)
        //    : base(value)
        //{
        //    NodeType = NodeType.Attribute;
        //    AttributeType = type;
        //}

        //public AttributeType AttributeType { get; set; }

        //public override void Add(Node node)
        //{
        //    throw new NotImplementedException();
        //}

        //public override Node GetChild(int index)
        //{
        //    throw new NotImplementedException();
        //}

        //public override string CloseTag()
        //{
        //    throw new NotImplementedException();
        //}

        //public override string OpenTag()
        //{
        //    throw new NotImplementedException();
        //}

        //public override void Remove(Node node)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
