using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savage.Core.SourceCodeModeling.Structure
{
	public class Text : Element
    {
        string _value;
        public string Value
        {
            get {
				return _value; }
            set { _value = value; }
        }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                Text t = (Text)obj;
                return t.Value.Equals(Value);
            }
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
