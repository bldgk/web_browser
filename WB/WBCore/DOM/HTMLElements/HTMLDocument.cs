using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBCore.DOM.HTMLElements
{
    public class HTMLDocument : Document
    {
        public HTMLDocument() : base()
        {
            NodeName = "Document";
        }

        public string Title { get; set; }

        //string referrer { get; set; }

        //string Domain { get; set; }

        //HTMLElement body;
        //HTMLCollection  images;
        //HTMLCollection  applets;
        //HTMLCollection  links;
        //HTMLCollection  forms;
        //HTMLCollection  anchors;
        public string Cookie { get; set; }
        //// raises(DOMException) on setting

        public ArrayList GetElementsByName(string elementName)
        {
            return new ArrayList();
        }
    }
}