﻿// Decompiled with JetBrains decompiler
// Type: HtmlAgilityPack.EncodingFoundException
// Assembly: HtmlAgilityPack, Version=1.4.6.0, Culture=neutral, PublicKeyToken=bd319b19eaf3b43a
// MVID: 33288599-2B93-45A3-99F5-D89D6188B861
// Assembly location: C:\Users\kiril_000\Downloads\HtmlAgilityPack.1.4.6\Net45\HtmlAgilityPack.dll

using System;
using System.Text;

namespace HtmlAgilityPack
{
  internal class EncodingFoundException : Exception
  {
    private Encoding _encoding;

    internal Encoding Encoding
    {
      get
      {
        return this._encoding;
      }
    }

    internal EncodingFoundException(Encoding encoding)
    {
      this._encoding = encoding;
    }
  }
}
