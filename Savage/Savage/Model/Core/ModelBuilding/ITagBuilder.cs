using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Savage.Core.ModelBuilding
{
	public interface ITagBuilder
    {
        void Build(object buildingElement, ref Grid buildingSpace);
    }
}
