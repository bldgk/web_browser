using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Savage.Core.SourceCodeModeling.Structure
{
	public class Root : Tag//, IAllowsNestingSelf
    {
        public IEnumerable<Type> NestingBreakers { get { return new Type[0]; } }

        public Root()
            : this(new Element[0])
        {
        }

        public Root(params Element[] children)
            : this(new TagAttribute[0], children)
        {
        }

        public Root(IEnumerable<TagAttribute> attributes, params Element[] children)
			 : base()
		{
			children.ToList().ForEach(child => AddChild(child));
			ElementName = "Root";
        }

		//public Root(params Element[] children)
		//   : this(new TagAttribute[0], children)
		//{
		//}
		//public Root(params TagAttribute[] attributes)
		//	: this(attributes, new Element[0])
		//{
		//}

		//public Root(IEnumerable<TagAttribute> attributes, params Element[] children)
		//	 : base()
		//{
		//	foreach (var child in children)
		//	{
		//		AddChild(child);
		//	}
		//	foreach (var attribute in attributes)
		//	{
		//		this.attributes.Add(attribute.Name, attribute);
		//	}

		//	ElementName = "Root";
		//}

	}
}
