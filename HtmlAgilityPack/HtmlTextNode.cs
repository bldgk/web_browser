// Decompiled with JetBrains decompiler
// Type: HtmlAgilityPack.HtmlTextNode
// Assembly: HtmlAgilityPack, Version=1.4.6.0, Culture=neutral, PublicKeyToken=bd319b19eaf3b43a
// MVID: 33288599-2B93-45A3-99F5-D89D6188B861
// Assembly location: C:\Users\kiril_000\Downloads\HtmlAgilityPack.1.4.6\Net45\HtmlAgilityPack.dll

namespace HtmlAgilityPack
{
  /// <summary>
  /// Represents an HTML text node.
  /// 
  /// </summary>
  public class HtmlTextNode : HtmlNode
  {
    private string _text;

    /// <summary>
    /// Gets or Sets the HTML between the start and end tags of the object. In the case of a text node, it is equals to OuterHtml.
    /// 
    /// </summary>
    public override string InnerHtml
    {
      get
      {
        return this.OuterHtml;
      }
      set
      {
        this._text = value;
      }
    }

    /// <summary>
    /// Gets or Sets the object and its content in HTML.
    /// 
    /// </summary>
    public override string OuterHtml
    {
      get
      {
        if (this._text == null)
          return base.OuterHtml;
        return this._text;
      }
    }

    /// <summary>
    /// Gets or Sets the text of the node.
    /// 
    /// </summary>
    public string Text
    {
      get
      {
        if (this._text == null)
          return base.OuterHtml;
        return this._text;
      }
      set
      {
        this._text = value;
      }
    }

    internal HtmlTextNode(HtmlDocument ownerdocument, int index)
      : base(HtmlNodeType.Text, ownerdocument, index)
    {
    }
  }
}
