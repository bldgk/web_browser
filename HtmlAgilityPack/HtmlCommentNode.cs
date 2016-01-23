// Decompiled with JetBrains decompiler
// Type: HtmlAgilityPack.HtmlCommentNode
// Assembly: HtmlAgilityPack, Version=1.4.6.0, Culture=neutral, PublicKeyToken=bd319b19eaf3b43a
// MVID: 33288599-2B93-45A3-99F5-D89D6188B861
// Assembly location: C:\Users\kiril_000\Downloads\HtmlAgilityPack.1.4.6\Net45\HtmlAgilityPack.dll

namespace HtmlAgilityPack
{
  /// <summary>
  /// Represents an HTML comment.
  /// 
  /// </summary>
  public class HtmlCommentNode : HtmlNode
  {
    private string _comment;

    /// <summary>
    /// Gets or Sets the comment text of the node.
    /// 
    /// </summary>
    public string Comment
    {
      get
      {
        if (this._comment == null)
          return base.InnerHtml;
        return this._comment;
      }
      set
      {
        this._comment = value;
      }
    }

    /// <summary>
    /// Gets or Sets the HTML between the start and end tags of the object. In the case of a text node, it is equals to OuterHtml.
    /// 
    /// </summary>
    public override string InnerHtml
    {
      get
      {
        if (this._comment == null)
          return base.InnerHtml;
        return this._comment;
      }
      set
      {
        this._comment = value;
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
        if (this._comment == null)
          return base.OuterHtml;
        return "<!--" + this._comment + "-->";
      }
    }

    internal HtmlCommentNode(HtmlDocument ownerdocument, int index)
      : base(HtmlNodeType.Comment, ownerdocument, index)
    {
    }
  }
}
