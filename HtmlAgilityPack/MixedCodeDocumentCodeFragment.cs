// Decompiled with JetBrains decompiler
// Type: HtmlAgilityPack.MixedCodeDocumentCodeFragment
// Assembly: HtmlAgilityPack, Version=1.4.6.0, Culture=neutral, PublicKeyToken=bd319b19eaf3b43a
// MVID: 33288599-2B93-45A3-99F5-D89D6188B861
// Assembly location: C:\Users\kiril_000\Downloads\HtmlAgilityPack.1.4.6\Net45\HtmlAgilityPack.dll

namespace HtmlAgilityPack
{
  /// <summary>
  /// Represents a fragment of code in a mixed code document.
  /// 
  /// </summary>
  public class MixedCodeDocumentCodeFragment : MixedCodeDocumentFragment
  {
    private string _code;

    /// <summary>
    /// Gets the fragment code text.
    /// 
    /// </summary>
    public string Code
    {
      get
      {
        if (this._code == null)
        {
          this._code = this.FragmentText.Substring(this.Doc.TokenCodeStart.Length, this.FragmentText.Length - this.Doc.TokenCodeEnd.Length - this.Doc.TokenCodeStart.Length - 1).Trim();
          if (this._code.StartsWith("="))
            this._code = this.Doc.TokenResponseWrite + this._code.Substring(1, this._code.Length - 1);
        }
        return this._code;
      }
      set
      {
        this._code = value;
      }
    }

    internal MixedCodeDocumentCodeFragment(MixedCodeDocument doc)
      : base(doc, MixedCodeDocumentFragmentType.Code)
    {
    }
  }
}
