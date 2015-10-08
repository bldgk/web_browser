using System;
using WebKit.Interop;

namespace WBCore.DOM
{
    public class ProcessingInstruction : Node
    {
        private IDOMProcessingInstruction DOMProcessingInstruction;
        public string Data
        {
            get
            {
                return DOMProcessingInstruction.data();
            }
            set
            {
                DOMProcessingInstruction.setData(value);
            }
        }
        public string Target
        {
            get
            {
                return DOMProcessingInstruction.target();
            }
        }

        protected ProcessingInstruction(IDOMProcessingInstruction ProcessingInstruction)
            : base(ProcessingInstruction)
        {
            DOMProcessingInstruction = ProcessingInstruction;
        }

        internal static ProcessingInstruction Create(IDOMProcessingInstruction ProcessingInstruction)
        {
            return new ProcessingInstruction(ProcessingInstruction);
        }
    }
}