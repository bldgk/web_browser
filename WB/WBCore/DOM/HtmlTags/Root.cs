using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WBCore.Dom.HtmlTags
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
        public Root(params TagAttribute[] attributes)
            : this(attributes, new Element[0])
        {
        }

        public Root(IEnumerable<TagAttribute> attributes, params Element[] children)
            : base(attributes, children)
        {
            Hidden = true;
            TagName = "[document]";
        }
    }
}
