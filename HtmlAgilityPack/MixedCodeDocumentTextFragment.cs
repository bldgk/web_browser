// Decompiled with JetBrains decompiler
// Type: HtmlAgilityPack.MixedCodeDocumentTextFragment
// Assembly: HtmlAgilityPack, Version=1.4.6.0, Culture=neutral, PublicKeyToken=bd319b19eaf3b43a
// MVID: 33288599-2B93-45A3-99F5-D89D6188B861
// Assembly location: C:\Users\kiril_000\Downloads\HtmlAgilityPack.1.4.6\Net45\HtmlAgilityPack.dll

namespace HtmlAgilityPack
{
  /// <summary>
  /// Represents a fragment of text in a mixed code document.
  /// 
  /// </summary>
  public class MixedCodeDocumentTextFragment : MixedCodeDocumentFragment
  {
    /// <summary>
    /// Gets the fragment text.
    /// 
    /// </summary>
    public string Text
    {
      get
      {
        return this.FragmentText;
      }
      set
      {
        this.FragmentText = value;
      }
    }

    internal MixedCodeDocumentTextFragment(MixedCodeDocument doc)
      : base(doc, MixedCodeDocumentFragmentType.Text)
    {
    }
  }
}
