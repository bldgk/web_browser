// Decompiled with JetBrains decompiler
// Type: HtmlAgilityPack.HtmlElementFlag
// Assembly: HtmlAgilityPack, Version=1.4.6.0, Culture=neutral, PublicKeyToken=bd319b19eaf3b43a
// MVID: 33288599-2B93-45A3-99F5-D89D6188B861
// Assembly location: C:\Users\kiril_000\Downloads\HtmlAgilityPack.1.4.6\Net45\HtmlAgilityPack.dll

using System;

namespace HtmlAgilityPack
{
  /// <summary>
  /// Flags that describe the behavior of an Element node.
  /// 
  /// </summary>
  [Flags]
  public enum HtmlElementFlag
  {
    CData = 1,
    Empty = 2,
    Closed = 4,
    CanOverlap = 8,
  }
}
