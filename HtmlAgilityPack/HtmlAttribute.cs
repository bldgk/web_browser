// Decompiled with JetBrains decompiler
// Type: HtmlAgilityPack.HtmlAttribute
// Assembly: HtmlAgilityPack, Version=1.4.6.0, Culture=neutral, PublicKeyToken=bd319b19eaf3b43a
// MVID: 33288599-2B93-45A3-99F5-D89D6188B861
// Assembly location: C:\Users\kiril_000\Downloads\HtmlAgilityPack.1.4.6\Net45\HtmlAgilityPack.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HtmlAgilityPack
{
  /// <summary>
  /// Represents an HTML attribute.
  /// 
  /// </summary>
  [DebuggerDisplay("Name: {OriginalName}, Value: {Value}")]
  public class HtmlAttribute : IComparable
  {
    private AttributeValueQuote _quoteType = AttributeValueQuote.DoubleQuote;
    private int _line;
    internal int _lineposition;
    internal string _name;
    internal int _namelength;
    internal int _namestartindex;
    internal HtmlDocument _ownerdocument;
    internal HtmlNode _ownernode;
    internal int _streamposition;
    internal string _value;
    internal int _valuelength;
    internal int _valuestartindex;

    /// <summary>
    /// Gets the line number of this attribute in the document.
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
    /// Gets the column number of this attribute in the document.
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
    /// Gets the qualified name of the attribute.
    /// 
    /// </summary>
    public string Name
    {
      get
      {
        if (this._name == null)
          this._name = this._ownerdocument.Text.Substring(this._namestartindex, this._namelength);
        return this._name.ToLower();
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException("value");
        this._name = value;
        if (this._ownernode == null)
          return;
        this._ownernode._innerchanged = true;
        this._ownernode._outerchanged = true;
      }
    }

    /// <summary>
    /// Name of attribute with original case
    /// 
    /// </summary>
    public string OriginalName
    {
      get
      {
        return this._name;
      }
    }

    /// <summary>
    /// Gets the HTML document to which this attribute belongs.
    /// 
    /// </summary>
    public HtmlDocument OwnerDocument
    {
      get
      {
        return this._ownerdocument;
      }
    }

    /// <summary>
    /// Gets the HTML node to which this attribute belongs.
    /// 
    /// </summary>
    public HtmlNode OwnerNode
    {
      get
      {
        return this._ownernode;
      }
    }

    /// <summary>
    /// Specifies what type of quote the data should be wrapped in
    /// 
    /// </summary>
    public AttributeValueQuote QuoteType
    {
      get
      {
        return this._quoteType;
      }
      set
      {
        this._quoteType = value;
      }
    }

    /// <summary>
    /// Gets the stream position of this attribute in the document, relative to the start of the document.
    /// 
    /// </summary>
    public int StreamPosition
    {
      get
      {
        return this._streamposition;
      }
    }

    /// <summary>
    /// Gets or sets the value of the attribute.
    /// 
    /// </summary>
    public string Value
    {
      get
      {
        if (this._value == null)
          this._value = this._ownerdocument.Text.Substring(this._valuestartindex, this._valuelength);
        return this._value;
      }
      set
      {
        this._value = value;
        if (this._ownernode == null)
          return;
        this._ownernode._innerchanged = true;
        this._ownernode._outerchanged = true;
      }
    }

    internal string XmlName
    {
      get
      {
        return HtmlDocument.GetXmlName(this.Name);
      }
    }

    internal string XmlValue
    {
      get
      {
        return this.Value;
      }
    }

    /// <summary>
    /// Gets a valid XPath string that points to this Attribute
    /// 
    /// </summary>
    public string XPath
    {
      get
      {
        return (this.OwnerNode == null ? "/" : this.OwnerNode.XPath + "/") + this.GetRelativeXpath();
      }
    }

    internal HtmlAttribute(HtmlDocument ownerdocument)
    {
      this._ownerdocument = ownerdocument;
    }

    /// <summary>
    /// Compares the current instance with another attribute. Comparison is based on attributes' name.
    /// 
    /// </summary>
    /// <param name="obj">An attribute to compare with this instance.</param>
    /// <returns>
    /// A 32-bit signed integer that indicates the relative order of the names comparison.
    /// </returns>
    public int CompareTo(object obj)
    {
      HtmlAttribute htmlAttribute = obj as HtmlAttribute;
      if (htmlAttribute == null)
        throw new ArgumentException("obj");
      return this.Name.CompareTo(htmlAttribute.Name);
    }

    /// <summary>
    /// Creates a duplicate of this attribute.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// The cloned attribute.
    /// </returns>
    public HtmlAttribute Clone()
    {
      return new HtmlAttribute(this._ownerdocument)
      {
        Name = this.Name,
        Value = this.Value
      };
    }

    /// <summary>
    /// Removes this attribute from it's parents collection
    /// 
    /// </summary>
    public void Remove()
    {
      this._ownernode.Attributes.Remove(this);
    }

    private string GetRelativeXpath()
    {
      if (this.OwnerNode == null)
        return this.Name;
      int num = 1;
      foreach (HtmlAttribute htmlAttribute in (IEnumerable<HtmlAttribute>) this.OwnerNode.Attributes)
      {
        if (!(htmlAttribute.Name != this.Name))
        {
          if (htmlAttribute != this)
            ++num;
          else
            break;
        }
      }
      return "@" + (object) this.Name + "[" + (string) (object) num + "]";
    }
  }
}
