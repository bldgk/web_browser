using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKit.Interop;

namespace WBCore.DOM
{
    public class CharacterData : IElement
    {
        IDOMCharacterData DOMCharacterData;

        public string Data
        {
            get
            {
                return DOMCharacterData.data();
            }
            set
            {
                DOMCharacterData.setData(value);
            }
        }

        public int Length
        {
            get
            {
                return
                      (int)DOMCharacterData.length();
            }
        }

        protected CharacterData(IDOMCharacterData CharacterData)
            : base(CharacterData)
        {
            DOMCharacterData = CharacterData;
        }

        internal static CharacterData Create(IDOMCharacterData iDOMCharacterData)
        {
            if (iDOMCharacterData is IDOMComment)
                return Comment.Create(iDOMCharacterData as IDOMComment);
            else if (iDOMCharacterData is IDOMText)
                return Text.Create(iDOMCharacterData as IDOMText);
            else
                return new CharacterData(iDOMCharacterData);
        }

        public string SubstringData(int Offset, int Count) =>
            DOMCharacterData.substringData((uint)Offset, (uint)Count);

        public void AppendData(string Data) =>
            DOMCharacterData.appendData(Data);

        public void DeleteData(int Offset, int Count) =>
            DOMCharacterData.deleteData((uint)Offset, (uint)Count);

        public void InsertData(int Offset, string Data) =>
            DOMCharacterData.insertData((uint)Offset, Data);

        public void ReplaceData(int Offset, int Count, string Data) =>
            DOMCharacterData.replaceData((uint)Offset, (uint)Count, Data);
    }
}