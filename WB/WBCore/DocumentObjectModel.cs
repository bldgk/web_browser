using System.IO;
using WBCore.DocumentObjectModelClasses;
using System.Windows;

namespace WBCore
{
    public class DocumentObjectModel
    {
		public DocumentObjectModel()
		{
		}		

        public DocumentObjectModel(Root root)
        {
            Root = root;
        }

        public Root Root { get; set; } = new Root();

    }
}