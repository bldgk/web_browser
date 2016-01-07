using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavageCore.SourceCodeModeling.Structure
{
	public interface IAllowsNestingSelf
    {
        IEnumerable<Type> NestingBreakers { get; }
    }
}
