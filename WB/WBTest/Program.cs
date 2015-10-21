using System;
using System.Linq;

namespace WBTest
{
    public class ABC : C
    {
        public ABC()
        {
            AA = "A";
            BB = "B";
            CC = "C";
        }

        public override string Tostr()
        {
            return base.Tostr();
        }
    }

    public abstract class A
    {
        public A()
        {
        }

        public string AA { get; set; }

        public virtual string Tostr() => AA;
    }

    public abstract class B : A
    {
        public B()
        {
        }

        public string BB { get; set; }

        public override string Tostr()
        {
            return base.Tostr() + BB;
        }
    }

    public abstract class C : B
    {
        public C()
        {
        }

        public string CC { get; set; }

        public override string Tostr()
        {
            return base.Tostr() + CC;
        }
    }

    public class Program
    {
        public delegate void Del(string message);

        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }

        public static void DelegateMethodReverse(string message)
        {
            string text = String.Empty;
            foreach (var t in message.Reverse().ToList())
            {
                text += t.ToString();
            }
            Console.WriteLine(text);
        }

        public static void MethodWithCallback(int param1, int param2, Del callback)
        {
            callback("The number is: " + (param1 + param2).ToString());
        }

        public static void Main(string[] args)
        {
            ABC abc = new ABC();
            Console.WriteLine(abc.Tostr());
            Console.ReadKey();
        }
    }
}