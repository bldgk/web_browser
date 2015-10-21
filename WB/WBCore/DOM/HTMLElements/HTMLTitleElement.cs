using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBCore.DOM.HTMLElements
{
    public class HTMLTitleElement : HTMLElement
    {
        public HTMLTitleElement() : base()
        {
        }

        public HTMLTitleElement(string text) : base()
        {
            Text = text;
        }

        public string Text { get; set; }
                
    }
}
