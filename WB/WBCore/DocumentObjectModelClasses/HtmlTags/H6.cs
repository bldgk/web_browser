using System;
using System.Collections.Generic;
namespace WBCore.DocumentObjectModelClasses.HtmlTags
{
    public class H6 : Tag
    {
        public string Align { get { return this["align"]; } }

        public string Class { get { return this["class"]; } }

        public string Dir { get { return this["dir"]; } }

        public string Id { get { return this["id"]; } }

        public string Lang { get { return this["lang"]; } }

        public string Onclick { get { return this["onclick"]; } }

        public string Ondblclick { get { return this["ondblclick"]; } }

        public string Onkeydown { get { return this["onkeydown"]; } }

        public string Onkeypress { get { return this["onkeypress"]; } }

        public string Onkeyup { get { return this["onkeyup"]; } }

        public string Onmousedown { get { return this["onmousedown"]; } }

        public string Onmousemove { get { return this["onmousemove"]; } }

        public string Onmouseout { get { return this["onmouseout"]; } }

        public string Onmouseover { get { return this["onmouseover"]; } }

        public string Onmouseup { get { return this["onmouseup"]; } }

        public string Style { get { return this["style"]; } }

        public string Title { get { return this["title"]; } }

        public H6()
            : this(new Element[0])
        {
        }

        public H6(params Element[] children)
            : this(new TagAttribute[0], children)
        {
        }

        public H6(params TagAttribute[] attributes)
            : this(attributes, new Element[0])
        {
        }

        public H6(IEnumerable<TagAttribute> attributes, params Element[] children)
            : base(attributes, children)
        {
            TagName = "h6";
        }
    }
}