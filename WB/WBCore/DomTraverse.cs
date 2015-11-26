using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBCore.DocumentObjectModelClasses;

namespace WBCore
{
    class DomTraverse
    {
        delegate void TreeVisitor<T>(T nodeData);


        private LinkedList<Element> children;

        //            public NTree(T data)E
        //            {
        //                this.data = data;
        //                children = new LinkedList<NTree<T>>();
        //            }

        //            public void AddChild(T data)
        //            {
        //                children.AddFirst(new NTree<T>(data));
        //            }

        //            public NTree<T> GetChild(int i)
        //            {
        //                foreach (NTree<T> n in children)
        //                    if (--i == 0)
        //                        return n;
        //                return null;
        //            }

        //            public void Traverse(NTree<T> node, TreeVisitor<T> visitor)
        //            {
        //                visitor(node.data);
        //                foreach (NTree<T> kid in node.children)
        //                    Traverse(kid, visitor);
        //            }
        //        }
        //    }
        //}
    }
}
