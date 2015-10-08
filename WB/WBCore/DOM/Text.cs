using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKit.Interop;

namespace WBCore.DOM
{
    public class Text : CharacterData
    {
        private IDOMText DOMText;

        protected Text(IDOMText Text)
            : base(Text)
        {
            DOMText = Text;
        }

        internal static Text Create(IDOMText Text)
        {
            if (Text is IDOMCDATASection)
                return CDATASection.Create(Text as IDOMCDATASection);
            else
                return new Text(Text);
        }

        public Text SplitText(int Offset)
        {
            return Text.Create(DOMText.splitText((uint)Offset));
        }
    }
}