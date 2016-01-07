using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBCore.DocumentObjectModelClasses;

namespace WBCore
{
	public static class Core
	{
		public static DocumentObjectModel GetModelFromSourceCode(string src)
		{
			return new DocumentObjectModel(new Parser().Parse(src));
		}

		public static Root Parse(string src)
		{
			return new Parser().Parse(src);
		}
	}
}
