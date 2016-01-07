using Savage.Core.ModelBuilding;
using Savage.Core.SourceCodeModeling.Handlers;
using Savage.Core.SourceCodeModeling.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Savage.Core
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
		public static string PrintModel(DocumentObjectModel model)
		{
			return model.Root.Print();
		}
		public static void Build(string src, ref Grid buildingSpace)
		{
			Build(GetModelFromSourceCode(src),ref buildingSpace);
		}
		public static void Build(DocumentObjectModel model, ref Grid buildingSpace)
		{
			new DomBuilder(model).BuildModel(ref buildingSpace);
		}
	}
}
