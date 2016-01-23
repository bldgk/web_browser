// Decompiled with JetBrains decompiler
// Type: HtmlAgilityPack.MixedCodeDocumentFragment
// Assembly: HtmlAgilityPack, Version=1.4.6.0, Culture=neutral, PublicKeyToken=bd319b19eaf3b43a
// MVID: 33288599-2B93-45A3-99F5-D89D6188B861
// Assembly location: C:\Users\kiril_000\Downloads\HtmlAgilityPack.1.4.6\Net45\HtmlAgilityPack.dll

namespace HtmlAgilityPack
{
  /// <summary>
  /// Represents a base class for fragments in a mixed code document.
  /// 
  /// </summary>
  public abstract class MixedCodeDocumentFragment
  {
    internal MixedCodeDocument Doc;
    private string _fragmentText;
    internal int Index;
    internal int Length;
    private int _line;
    internal int _lineposition;
    internal MixedCodeDocumentFragmentType _type;

    /// <summary>
    /// Gets the fragement text.
    /// 
    /// </summary>
    public string FragmentText
    {
      get
      {
        if (this._fragmentText == null)
          this._fragmentText = this.Doc._text.Substring(this.Index, this.Length);
        return this.FragmentText;
      }
      internal set
      {
        this._fragmentText = value;
      }
    }

    /// <summary>
    /// Gets the type of fragment.
    /// 
    /// </summary>
    public MixedCodeDocumentFragmentType FragmentType
    {
      get
      {
        return this._type;
      }
    }

    /// <summary>
    /// Gets the line number of the fragment.
    /// 
    /// </summary>
    public int Line
    {
      get
      {
        return this._line;
      }
      internal set
      {
        this._line = value;
      }
    }

    /// <summary>
    /// Gets the line position (column) of the fragment.
    /// 
    /// </summary>
    public int LinePosition
    {
      get
      {
        return this._lineposition;
      }
    }

    /// <summary>
    /// Gets the fragment position in the document's stream.
    /// 
    /// </summary>
    public int StreamPosition
    {
      get
      {
        return this.Index;
      }
    }

    internal MixedCodeDocumentFragment(MixedCodeDocument doc, MixedCodeDocumentFragmentType type)
    {
      this.Doc = doc;
      this._type = type;
      switch (type)
      {
        case MixedCodeDocumentFragmentType.Code:
          this.Doc._codefragments.Append(this);
          break;
        case MixedCodeDocumentFragmentType.Text:
          this.Doc._textfragments.Append(this);
          break;
      }
      this.Doc._fragments.Append(this);
    }
  }
}
