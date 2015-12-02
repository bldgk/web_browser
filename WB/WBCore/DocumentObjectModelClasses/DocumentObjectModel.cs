using System.IO;
using WBCore.DocumentObjectModelClasses.BuildingClasses;
using WBCore.DocumentObjectModelClasses.HtmlElements;
using WBCore.DocumentObjectModelClasses.HtmlTags;

namespace WBCore.DocumentObjectModelClasses
{
    public class DocumentObjectModel
    {
        DomBuilder ModelBuilder { get; set;}
        public DocumentObjectModel()
        {
            ModelBuilder = new DomBuilder();
        }

        public DocumentObjectModel(DomBuilder dombuilder)
        {
            ModelBuilder = dombuilder;
        }

        public DocumentObjectModel(Root root)
        {
            Root = root;
            ModelBuilder = new DomBuilder();
        }

        public Root Root { get; set; } = new Root();


        public void BuildModel()
        {
            ModelBuilder.Build(Root);
        }

    }
}