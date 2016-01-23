// Decompiled with JetBrains decompiler
// Type: HtmlAgilityPack.HtmlWebException
// Assembly: HtmlAgilityPack, Version=1.4.6.0, Culture=neutral, PublicKeyToken=bd319b19eaf3b43a
// MVID: 33288599-2B93-45A3-99F5-D89D6188B861
// Assembly location: C:\Users\kiril_000\Downloads\HtmlAgilityPack.1.4.6\Net45\HtmlAgilityPack.dll

using System;

namespace HtmlAgilityPack
{
  /// <summary>
  /// Represents an exception thrown by the HtmlWeb utility class.
  /// 
  /// </summary>
  public class HtmlWebException : Exception
  {
    /// <summary>
    /// Creates an instance of the HtmlWebException.
    /// 
    /// </summary>
    /// <param name="message">The exception's message.</param>
    public HtmlWebException(string message)
      : base(message)
    {
    }
  }
}
