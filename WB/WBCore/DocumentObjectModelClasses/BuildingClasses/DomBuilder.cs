using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WBCore.DocumentObjectModelClasses;

namespace WBCore.DocumentObjectModelClasses.BuildingClasses
{

    public class DomBuilder
    {
        public Dictionary<string, ITagBuilder> BuilderMap = new Dictionary<string, ITagBuilder>();
        ITagBuilder TagBuilder { get; set; }
        public DomBuilder()
        {

        }

        public void Build(Element x)
        {

            string type = "WBCore.DocumentObjectModelClasses.BuildingClasses." + x.GetType().Name + "Builder";
            if (BuilderMap.ContainsKey(type))
            {
                TagBuilder = BuilderMap[type];
            }
            else
            {

                Type TagType = Type.GetType(type, false, true);
                if (TagType != null)
                {
                    //получаем конструктор
                    ConstructorInfo ci = TagType.GetConstructor(
                        new Type[] { });

                    //вызываем конструтор
                    object Obj = ci.Invoke(new object[] { });
                    TagBuilder = Obj as ITagBuilder;
                    BuilderMap.Add(type, Obj as ITagBuilder);
                }
                else
                {

                }
            }
            TagBuilder?.Build();

            x.Children.ToList().ForEach(p => Build(p));
        }
    }
}