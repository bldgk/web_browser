using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBCore;
using WBCore.DocumentObjectModelClasses;
using WebBrowserConrolProject.ModelBuilding;

namespace WB
{
	public static class Assistant
	{
		public static DocumentObjectModel GetModelFromSourceCode(string src)
		{
			return Core.GetModelFromSourceCode(src);
		}

		public static Root Parse(string src)
		{
			return Core.Parse(src);
		}

		public static string PrintModel(DocumentObjectModel model)
		{
			return model.Root.Print();
		}
		public static  void Build(string src)
		{
			Build(GetModelFromSourceCode(src));
		}
		public static void Build(DocumentObjectModel model)
		{
			new DomBuilder(model).BuildModel();
		}
	}
}