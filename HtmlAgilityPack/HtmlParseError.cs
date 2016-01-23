// Decompiled with JetBrains decompiler
// Type: HtmlAgilityPack.HtmlParseError
// Assembly: HtmlAgilityPack, Version=1.4.6.0, Culture=neutral, PublicKeyToken=bd319b19eaf3b43a
// MVID: 33288599-2B93-45A3-99F5-D89D6188B861
// Assembly location: C:\Users\kiril_000\Downloads\HtmlAgilityPack.1.4.6\Net45\HtmlAgilityPack.dll

namespace HtmlAgilityPack
{
  /// <summary>
  /// Represents a parsing error found during document parsing.
  /// 
  /// </summary>
  public class HtmlParseError
  {
    private HtmlParseErrorCode _code;
    private int _line;
    private int _linePosition;
    private string _reason;
    private string _sourceText;
    private int _streamPosition;

    /// <summary>
    /// Gets the type of error.
    /// 
    /// </summary>
    public HtmlParseErrorCode Code
    {
      get
      {
        return this._code;
      }
    }

    /// <summary>
    /// Gets the line number of this error in the document.
    /// 
    /// </summary>
    public int Line
    {
      get
      {
        return this._line;
      }
    }

    /// <summary>
    /// Gets the column number of this error in the document.
    /// 
    /// </summary>
    public int LinePosition
    {
      get
      {
        return this._linePosition;
      }
    }

    /// <summary>
    /// Gets a description for the error.
    /// 
    /// </summary>
    public string Reason
    {
      get
      {
        return this._reason;
      }
    }

    /// <summary>
    /// Gets the the full text of the line containing the error.
    /// 
    /// </summary>
    public string SourceText
    {
      get
      {
        return this._sourceText;
      }
    }

    /// <summary>
    /// Gets the absolute stream position of this error in the document, relative to the start of the document.
    /// 
    /// </summary>
    public int StreamPosition
    {
      get
      {
        return this._streamPosition;
      }
    }

    internal HtmlParseError(HtmlParseErrorCode code, int line, int linePosition, int streamPosition, string sourceText, string reason)
    {
      this._code = code;
      this._line = line;
      this._linePosition = linePosition;
      this._streamPosition = streamPosition;
      this._sourceText = sourceText;
      this._reason = reason;
    }
  }
}
