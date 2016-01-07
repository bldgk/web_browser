using SavageCore.SourceCodeModeling.Handlers;
using SavageCore.SourceCodeModeling.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SavageCore.Core
{
	public static class CoreAssistant
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
