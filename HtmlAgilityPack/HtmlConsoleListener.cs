// Decompiled with JetBrains decompiler
// Type: HtmlAgilityPack.HtmlConsoleListener
// Assembly: HtmlAgilityPack, Version=1.4.6.0, Culture=neutral, PublicKeyToken=bd319b19eaf3b43a
// MVID: 33288599-2B93-45A3-99F5-D89D6188B861
// Assembly location: C:\Users\kiril_000\Downloads\HtmlAgilityPack.1.4.6\Net45\HtmlAgilityPack.dll

using System;
using System.Diagnostics;

namespace HtmlAgilityPack
{
  internal class HtmlConsoleListener : TraceListener
  {
    public override void Write(string Message)
    {
      this.Write(Message, "");
    }

    public override void Write(string Message, string Category)
    {
      Console.Write("T:" + Category + ": " + Message);
    }

    public override void WriteLine(string Message)
    {
      this.Write(Message + "\n");
    }

    public override void WriteLine(string Message, string Category)
    {
      this.Write(Message + "\n", Category);
    }
  }
}
