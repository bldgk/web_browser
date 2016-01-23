// Decompiled with JetBrains decompiler
// Type: HtmlAgilityPack.Trace
// Assembly: HtmlAgilityPack, Version=1.4.6.0, Culture=neutral, PublicKeyToken=bd319b19eaf3b43a
// MVID: 33288599-2B93-45A3-99F5-D89D6188B861
// Assembly location: C:\Users\kiril_000\Downloads\HtmlAgilityPack.1.4.6\Net45\HtmlAgilityPack.dll

namespace HtmlAgilityPack
{
  internal class Trace
  {
    internal static Trace _current;

    internal static Trace Current
    {
      get
      {
        if (Trace._current == null)
          Trace._current = new Trace();
        return Trace._current;
      }
    }

    public static void WriteLine(string message, string category)
    {
      Trace.Current.WriteLineIntern(message, category);
    }

    private void WriteLineIntern(string message, string category)
    {
    }
  }
}
