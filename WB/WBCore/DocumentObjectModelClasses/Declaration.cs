using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBCore.DocumentObjectModelClasses
{
    public class Declaration : Text
    {
        public override string ToString()
        {
            return "<!" + base.ToString() + ">";
        }
    }
}
