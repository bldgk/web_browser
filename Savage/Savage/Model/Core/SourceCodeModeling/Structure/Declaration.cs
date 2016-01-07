using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savage.Core.SourceCodeModeling.Structure
{
	public class Declaration : Text
    {
        public override string ToString()
        {
            return "<!" + base.ToString() + ">";
        }
    }
}
