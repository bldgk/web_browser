// Decompiled with JetBrains decompiler
// Type: HtmlAgilityPack.Utilities
// Assembly: HtmlAgilityPack, Version=1.4.6.0, Culture=neutral, PublicKeyToken=bd319b19eaf3b43a
// MVID: 33288599-2B93-45A3-99F5-D89D6188B861
// Assembly location: C:\Users\kiril_000\Downloads\HtmlAgilityPack.1.4.6\Net45\HtmlAgilityPack.dll

using System.Collections.Generic;

namespace HtmlAgilityPack
{
  internal static class Utilities
  {
    public static TValue GetDictionaryValueOrNull<TKey, TValue>(Dictionary<TKey, TValue> dict, TKey key) where TKey : class
    {
      if (!dict.ContainsKey(key))
        return default (TValue);
      return dict[key];
    }
  }
}
