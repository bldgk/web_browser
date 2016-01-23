// Decompiled with JetBrains decompiler
// Type: HtmlAgilityPack.HtmlDocument
// Assembly: HtmlAgilityPack, Version=1.4.6.0, Culture=neutral, PublicKeyToken=bd319b19eaf3b43a
// MVID: 33288599-2B93-45A3-99F5-D89D6188B861
// Assembly location: C:\Users\kiril_000\Downloads\HtmlAgilityPack.1.4.6\Net45\HtmlAgilityPack.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.XPath;

namespace HtmlAgilityPack
{
  /// <summary>
  /// Represents a complete HTML document.
  /// 
  /// </summary>
  public class HtmlDocument : IXPathNavigable
  {
    internal static readonly string HtmlExceptionRefNotChild = "Reference node must be a child of this node";
    internal static readonly string HtmlExceptionUseIdAttributeFalse = "You need to set UseIdAttribute property to true to enable this feature";
    internal Dictionary<string, HtmlNode> Lastnodes = new Dictionary<string, HtmlNode>();
    private List<HtmlParseError> _parseerrors = new List<HtmlParseError>();
    /// <summary>
    /// Defines if non closed nodes will be checked at the end of parsing. Default is true.
    /// 
    /// </summary>
    public bool OptionCheckSyntax = true;
    /// <summary>
    /// Defines the maximum length of source text or parse errors. Default is 100.
    /// 
    /// </summary>
    public int OptionExtractErrorSourceTextMaxLength = 100;
    /// <summary>
    /// Defines if declared encoding must be read from the document.
    ///             Declared encoding is determined using the meta http-equiv="content-type" content="text/html;charset=XXXXX" html node.
    ///             Default is true.
    /// 
    /// </summary>
    public bool OptionReadEncoding = true;
    /// <summary>
    /// Defines if the 'id' attribute must be specifically used. Default is true.
    /// 
    /// </summary>
    public bool OptionUseIdAttribute = true;
    private int _c;
    private Crc32 _crc32;
    private HtmlAttribute _currentattribute;
    private HtmlNode _currentnode;
    private Encoding _declaredencoding;
    private HtmlNode _documentnode;
    private bool _fullcomment;
    private int _index;
    private HtmlNode _lastparentnode;
    private int _line;
    private int _lineposition;
    private int _maxlineposition;
    internal Dictionary<string, HtmlNode> Nodesid;
    private HtmlDocument.ParseState _oldstate;
    private bool _onlyDetectEncoding;
    internal Dictionary<int, HtmlNode> Openednodes;
    private string _remainder;
    private int _remainderOffset;
    private HtmlDocument.ParseState _state;
    private Encoding _streamencoding;
    internal string Text;
    /// <summary>
    /// Adds Debugging attributes to node. Default is false.
    /// 
    /// </summary>
    public bool OptionAddDebuggingAttributes;
    /// <summary>
    /// Defines if closing for non closed nodes must be done at the end or directly in the document.
    ///             Setting this to true can actually change how browsers render the page. Default is false.
    /// 
    /// </summary>
    public bool OptionAutoCloseOnEnd;
    /// <summary>
    /// Defines if a checksum must be computed for the document while parsing. Default is false.
    /// 
    /// </summary>
    public bool OptionComputeChecksum;
    /// <summary>
    /// Defines the default stream encoding to use. Default is System.Text.Encoding.Default.
    /// 
    /// </summary>
    public Encoding OptionDefaultStreamEncoding;
    /// <summary>
    /// Defines if source text must be extracted while parsing errors.
    ///             If the document has a lot of errors, or cascading errors, parsing performance can be dramatically affected if set to true.
    ///             Default is false.
    /// 
    /// </summary>
    public bool OptionExtractErrorSourceText;
    /// <summary>
    /// Defines if LI, TR, TH, TD tags must be partially fixed when nesting errors are detected. Default is false.
    /// 
    /// </summary>
    public bool OptionFixNestedTags;
    /// <summary>
    /// Defines if output must conform to XML, instead of HTML.
    /// 
    /// </summary>
    public bool OptionOutputAsXml;
    /// <summary>
    /// Defines if attribute value output must be optimized (not bound with double quotes if it is possible). Default is false.
    /// 
    /// </summary>
    public bool OptionOutputOptimizeAttributeValues;
    /// <summary>
    /// Defines if name must be output with it's original case. Useful for asp.net tags and attributes
    /// 
    /// </summary>
    public bool OptionOutputOriginalCase;
    /// <summary>
    /// Defines if name must be output in uppercase. Default is false.
    /// 
    /// </summary>
    public bool OptionOutputUpperCase;
    /// <summary>
    /// Defines the name of a node that will throw the StopperNodeException when found as an end node. Default is null.
    /// 
    /// </summary>
    public string OptionStopperNodeName;
    /// <summary>
    /// Defines if empty nodes must be written as closed during output. Default is false.
    /// 
    /// </summary>
    public bool OptionWriteEmptyNodes;

    /// <summary>
    /// Gets the document CRC32 checksum if OptionComputeChecksum was set to true before parsing, 0 otherwise.
    /// 
    /// </summary>
    public int CheckSum
    {
      get
      {
        if (this._crc32 != null)
          return (int) this._crc32.CheckSum;
        return 0;
      }
    }

    /// <summary>
    /// Gets the document's declared encoding.
    ///             Declared encoding is determined using the meta http-equiv="content-type" content="text/html;charset=XXXXX" html node.
    /// 
    /// </summary>
    public Encoding DeclaredEncoding
    {
      get
      {
        return this._declaredencoding;
      }
    }

    /// <summary>
    /// Gets the root node of the document.
    /// 
    /// </summary>
    public HtmlNode DocumentNode
    {
      get
      {
        return this._documentnode;
      }
    }

    /// <summary>
    /// Gets the document's output encoding.
    /// 
    /// </summary>
    public Encoding Encoding
    {
      get
      {
        return this.GetOutEncoding();
      }
    }

    /// <summary>
    /// Gets a list of parse errors found in the document.
    /// 
    /// </summary>
    public IEnumerable<HtmlParseError> ParseErrors
    {
      get
      {
        return (IEnumerable<HtmlParseError>) this._parseerrors;
      }
    }

    /// <summary>
    /// Gets the remaining text.
    ///             Will always be null if OptionStopperNodeName is null.
    /// 
    /// </summary>
    public string Remainder
    {
      get
      {
        return this._remainder;
      }
    }

    /// <summary>
    /// Gets the offset of Remainder in the original Html text.
    ///             If OptionStopperNodeName is null, this will return the length of the original Html text.
    /// 
    /// </summary>
    public int RemainderOffset
    {
      get
      {
        return this._remainderOffset;
      }
    }

    /// <summary>
    /// Gets the document's stream encoding.
    /// 
    /// </summary>
    public Encoding StreamEncoding
    {
      get
      {
        return this._streamencoding;
      }
    }

    /// <summary>
    /// Creates an instance of an HTML document.
    /// 
    /// </summary>
    public HtmlDocument()
    {
      this._documentnode = this.CreateNode(HtmlNodeType.Document, 0);
      this.OptionDefaultStreamEncoding = Encoding.Default;
    }

    /// <summary>
    /// Detects the encoding of an HTML document from a file first, and then loads the file.
    /// 
    /// </summary>
    /// <param name="path">The complete file path to be read.</param>
    public void DetectEncodingAndLoad(string path)
    {
      this.DetectEncodingAndLoad(path, true);
    }

    /// <summary>
    /// Detects the encoding of an HTML document from a file first, and then loads the file.
    /// 
    /// </summary>
    /// <param name="path">The complete file path to be read. May not be null.</param><param name="detectEncoding">true to detect encoding, false otherwise.</param>
    public void DetectEncodingAndLoad(string path, bool detectEncoding)
    {
      if (path == null)
        throw new ArgumentNullException("path");
      Encoding encoding = !detectEncoding ? (Encoding) null : this.DetectEncoding(path);
      if (encoding == null)
        this.Load(path);
      else
        this.Load(path, encoding);
    }

    /// <summary>
    /// Detects the encoding of an HTML file.
    /// 
    /// </summary>
    /// <param name="path">Path for the file containing the HTML document to detect. May not be null.</param>
    /// <returns>
    /// The detected encoding.
    /// </returns>
    public Encoding DetectEncoding(string path)
    {
      if (path == null)
        throw new ArgumentNullException("path");
      using (StreamReader streamReader = new StreamReader(path, this.OptionDefaultStreamEncoding))
        return this.DetectEncoding((TextReader) streamReader);
    }

    /// <summary>
    /// Loads an HTML document from a file.
    /// 
    /// </summary>
    /// <param name="path">The complete file path to be read. May not be null.</param>
    public void Load(string path)
    {
      if (path == null)
        throw new ArgumentNullException("path");
      using (StreamReader streamReader = new StreamReader(path, this.OptionDefaultStreamEncoding))
        this.Load((TextReader) streamReader);
    }

    /// <summary>
    /// Loads an HTML document from a file.
    /// 
    /// </summary>
    /// <param name="path">The complete file path to be read. May not be null.</param><param name="detectEncodingFromByteOrderMarks">Indicates whether to look for byte order marks at the beginning of the file.</param>
    public void Load(string path, bool detectEncodingFromByteOrderMarks)
    {
      if (path == null)
        throw new ArgumentNullException("path");
      using (StreamReader streamReader = new StreamReader(path, detectEncodingFromByteOrderMarks))
        this.Load((TextReader) streamReader);
    }

    /// <summary>
    /// Loads an HTML document from a file.
    /// 
    /// </summary>
    /// <param name="path">The complete file path to be read. May not be null.</param><param name="encoding">The character encoding to use. May not be null.</param>
    public void Load(string path, Encoding encoding)
    {
      if (path == null)
        throw new ArgumentNullException("path");
      if (encoding == null)
        throw new ArgumentNullException("encoding");
      using (StreamReader streamReader = new StreamReader(path, encoding))
        this.Load((TextReader) streamReader);
    }

    /// <summary>
    /// Loads an HTML document from a file.
    /// 
    /// </summary>
    /// <param name="path">The complete file path to be read. May not be null.</param><param name="encoding">The character encoding to use. May not be null.</param><param name="detectEncodingFromByteOrderMarks">Indicates whether to look for byte order marks at the beginning of the file.</param>
    public void Load(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks)
    {
      if (path == null)
        throw new ArgumentNullException("path");
      if (encoding == null)
        throw new ArgumentNullException("encoding");
      using (StreamReader streamReader = new StreamReader(path, encoding, detectEncodingFromByteOrderMarks))
        this.Load((TextReader) streamReader);
    }

    /// <summary>
    /// Loads an HTML document from a file.
    /// 
    /// </summary>
    /// <param name="path">The complete file path to be read. May not be null.</param><param name="encoding">The character encoding to use. May not be null.</param><param name="detectEncodingFromByteOrderMarks">Indicates whether to look for byte order marks at the beginning of the file.</param><param name="buffersize">The minimum buffer size.</param>
    public void Load(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks, int buffersize)
    {
      if (path == null)
        throw new ArgumentNullException("path");
      if (encoding == null)
        throw new ArgumentNullException("encoding");
      using (StreamReader streamReader = new StreamReader(path, encoding, detectEncodingFromByteOrderMarks, buffersize))
        this.Load((TextReader) streamReader);
    }
 
		/// <summary>
		/// Saves the mixed document to the specified file.
		/// 
		/// </summary>
		/// <param name="filename">The location of the file where you want to save the document.</param>
		public void Save(string filename)
    {
      using (StreamWriter writer = new StreamWriter(filename, false, this.GetOutEncoding()))
        this.Save(writer);
    }

    /// <summary>
    /// Saves the mixed document to the specified file.
    /// 
    /// </summary>
    /// <param name="filename">The location of the file where you want to save the document. May not be null.</param><param name="encoding">The character encoding to use. May not be null.</param>
    public void Save(string filename, Encoding encoding)
    {
      if (filename == null)
        throw new ArgumentNullException("filename");
      if (encoding == null)
        throw new ArgumentNullException("encoding");
      using (StreamWriter writer = new StreamWriter(filename, false, encoding))
        this.Save(writer);
    }

    /// <summary>
    /// Creates a new XPathNavigator object for navigating this HTML document.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// An XPathNavigator object. The XPathNavigator is positioned on the root of the document.
    /// </returns>
    public XPathNavigator CreateNavigator()
    {
      return (XPathNavigator) new HtmlNodeNavigator(this, this._documentnode);
    }

    /// <summary>
    /// Gets a valid XML name.
    /// 
    /// </summary>
    /// <param name="name">Any text.</param>
    /// <returns>
    /// A string that is a valid XML name.
    /// </returns>
    public static string GetXmlName(string name)
    {
      string str = string.Empty;
      bool flag = true;
      for (int index = 0; index < name.Length; ++index)
      {
        if ((int) name[index] >= 97 && (int) name[index] <= 122 || (int) name[index] >= 48 && (int) name[index] <= 57 || ((int) name[index] == 95 || (int) name[index] == 45 || (int) name[index] == 46))
        {
          str += (string) (object) name[index];
        }
        else
        {
          flag = false;
          Encoding utF8 = Encoding.UTF8;
          char[] chars = new char[1]
          {
            name[index]
          };
          foreach (byte num in utF8.GetBytes(chars))
            str += num.ToString("x2");
          str += "_";
        }
      }
      if (flag)
        return str;
      return "_" + str;
    }

    /// <summary>
    /// Applies HTML encoding to a specified string.
    /// 
    /// </summary>
    /// <param name="html">The input string to encode. May not be null.</param>
    /// <returns>
    /// The encoded string.
    /// </returns>
    public static string HtmlEncode(string html)
    {
      if (html == null)
        throw new ArgumentNullException("html");
      return new Regex("&(?!(amp;)|(lt;)|(gt;)|(quot;))", RegexOptions.IgnoreCase).Replace(html, "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;");
    }

    /// <summary>
    /// Determines if the specified character is considered as a whitespace character.
    /// 
    /// </summary>
    /// <param name="c">The character to check.</param>
    /// <returns>
    /// true if if the specified character is considered as a whitespace character.
    /// </returns>
    public static bool IsWhiteSpace(int c)
    {
      return c == 10 || c == 13 || (c == 32 || c == 9);
    }

    /// <summary>
    /// Creates an HTML attribute with the specified name.
    /// 
    /// </summary>
    /// <param name="name">The name of the attribute. May not be null.</param>
    /// <returns>
    /// The new HTML attribute.
    /// </returns>
    public HtmlAttribute CreateAttribute(string name)
    {
      if (name == null)
        throw new ArgumentNullException("name");
      HtmlAttribute attribute = this.CreateAttribute();
      attribute.Name = name;
      return attribute;
    }

    /// <summary>
    /// Creates an HTML attribute with the specified name.
    /// 
    /// </summary>
    /// <param name="name">The name of the attribute. May not be null.</param><param name="value">The value of the attribute.</param>
    /// <returns>
    /// The new HTML attribute.
    /// </returns>
    public HtmlAttribute CreateAttribute(string name, string value)
    {
      if (name == null)
        throw new ArgumentNullException("name");
      HtmlAttribute attribute = this.CreateAttribute(name);
      attribute.Value = value;
      return attribute;
    }

    /// <summary>
    /// Creates an HTML comment node.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// The new HTML comment node.
    /// </returns>
    public HtmlCommentNode CreateComment()
    {
      return (HtmlCommentNode) this.CreateNode(HtmlNodeType.Comment);
    }

    /// <summary>
    /// Creates an HTML comment node with the specified comment text.
    /// 
    /// </summary>
    /// <param name="comment">The comment text. May not be null.</param>
    /// <returns>
    /// The new HTML comment node.
    /// </returns>
    public HtmlCommentNode CreateComment(string comment)
    {
      if (comment == null)
        throw new ArgumentNullException("comment");
      HtmlCommentNode comment1 = this.CreateComment();
      comment1.Comment = comment;
      return comment1;
    }

    /// <summary>
    /// Creates an HTML element node with the specified name.
    /// 
    /// </summary>
    /// <param name="name">The qualified name of the element. May not be null.</param>
    /// <returns>
    /// The new HTML node.
    /// </returns>
    public HtmlNode CreateElement(string name)
    {
      if (name == null)
        throw new ArgumentNullException("name");
      HtmlNode node = this.CreateNode(HtmlNodeType.Element);
      node.Name = name;
      return node;
    }

    /// <summary>
    /// Creates an HTML text node.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// The new HTML text node.
    /// </returns>
    public HtmlTextNode CreateTextNode()
    {
      return (HtmlTextNode) this.CreateNode(HtmlNodeType.Text);
    }

    /// <summary>
    /// Creates an HTML text node with the specified text.
    /// 
    /// </summary>
    /// <param name="text">The text of the node. May not be null.</param>
    /// <returns>
    /// The new HTML text node.
    /// </returns>
    public HtmlTextNode CreateTextNode(string text)
    {
      if (text == null)
        throw new ArgumentNullException("text");
      HtmlTextNode textNode = this.CreateTextNode();
      textNode.Text = text;
      return textNode;
    }

    /// <summary>
    /// Detects the encoding of an HTML stream.
    /// 
    /// </summary>
    /// <param name="stream">The input stream. May not be null.</param>
    /// <returns>
    /// The detected encoding.
    /// </returns>
    public Encoding DetectEncoding(Stream stream)
    {
      if (stream == null)
        throw new ArgumentNullException("stream");
      return this.DetectEncoding((TextReader) new StreamReader(stream));
    }

    /// <summary>
    /// Detects the encoding of an HTML text provided on a TextReader.
    /// 
    /// </summary>
    /// <param name="reader">The TextReader used to feed the HTML. May not be null.</param>
    /// <returns>
    /// The detected encoding.
    /// </returns>
    public Encoding DetectEncoding(TextReader reader)
    {
      if (reader == null)
        throw new ArgumentNullException("reader");
      this._onlyDetectEncoding = true;
      this.Openednodes = !this.OptionCheckSyntax ? (Dictionary<int, HtmlNode>) null : new Dictionary<int, HtmlNode>();
      this.Nodesid = !this.OptionUseIdAttribute ? (Dictionary<string, HtmlNode>) null : new Dictionary<string, HtmlNode>();
      StreamReader streamReader = reader as StreamReader;
      this._streamencoding = streamReader == null ? (Encoding) null : streamReader.CurrentEncoding;
      this._declaredencoding = (Encoding) null;
      this.Text = reader.ReadToEnd();
      this._documentnode = this.CreateNode(HtmlNodeType.Document, 0);
      try
      {
        this.Parse();
      }
      catch (EncodingFoundException ex)
      {
        return ex.Encoding;
      }
      return (Encoding) null;
    }

    /// <summary>
    /// Detects the encoding of an HTML text.
    /// 
    /// </summary>
    /// <param name="html">The input html text. May not be null.</param>
    /// <returns>
    /// The detected encoding.
    /// </returns>
    public Encoding DetectEncodingHtml(string html)
    {
      if (html == null)
        throw new ArgumentNullException("html");
      using (StringReader stringReader = new StringReader(html))
        return this.DetectEncoding((TextReader) stringReader);
    }

    /// <summary>
    /// Gets the HTML node with the specified 'id' attribute value.
    /// 
    /// </summary>
    /// <param name="id">The attribute id to match. May not be null.</param>
    /// <returns>
    /// The HTML node with the matching id or null if not found.
    /// </returns>
    public HtmlNode GetElementbyId(string id)
    {
      if (id == null)
        throw new ArgumentNullException("id");
      if (this.Nodesid == null)
        throw new Exception(HtmlDocument.HtmlExceptionUseIdAttributeFalse);
      if (!this.Nodesid.ContainsKey(id.ToLower()))
        return (HtmlNode) null;
      return this.Nodesid[id.ToLower()];
    }

    /// <summary>
    /// Loads an HTML document from a stream.
    /// 
    /// </summary>
    /// <param name="stream">The input stream.</param>
    public void Load(Stream stream)
    {
      this.Load((TextReader) new StreamReader(stream, this.OptionDefaultStreamEncoding));
    }

    /// <summary>
    /// Loads an HTML document from a stream.
    /// 
    /// </summary>
    /// <param name="stream">The input stream.</param><param name="detectEncodingFromByteOrderMarks">Indicates whether to look for byte order marks at the beginning of the stream.</param>
    public void Load(Stream stream, bool detectEncodingFromByteOrderMarks)
    {
      this.Load((TextReader) new StreamReader(stream, detectEncodingFromByteOrderMarks));
    }

    /// <summary>
    /// Loads an HTML document from a stream.
    /// 
    /// </summary>
    /// <param name="stream">The input stream.</param><param name="encoding">The character encoding to use.</param>
    public void Load(Stream stream, Encoding encoding)
    {
      this.Load((TextReader) new StreamReader(stream, encoding));
    }

    /// <summary>
    /// Loads an HTML document from a stream.
    /// 
    /// </summary>
    /// <param name="stream">The input stream.</param><param name="encoding">The character encoding to use.</param><param name="detectEncodingFromByteOrderMarks">Indicates whether to look for byte order marks at the beginning of the stream.</param>
    public void Load(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks)
    {
      this.Load((TextReader) new StreamReader(stream, encoding, detectEncodingFromByteOrderMarks));
    }

    /// <summary>
    /// Loads an HTML document from a stream.
    /// 
    /// </summary>
    /// <param name="stream">The input stream.</param><param name="encoding">The character encoding to use.</param><param name="detectEncodingFromByteOrderMarks">Indicates whether to look for byte order marks at the beginning of the stream.</param><param name="buffersize">The minimum buffer size.</param>
    public void Load(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int buffersize)
    {
      this.Load((TextReader) new StreamReader(stream, encoding, detectEncodingFromByteOrderMarks, buffersize));
    }

    /// <summary>
    /// Loads the HTML document from the specified TextReader.
    /// 
    /// </summary>
    /// <param name="reader">The TextReader used to feed the HTML data into the document. May not be null.</param>
    public void Load(TextReader reader)
    {
      if (reader == null)
        throw new ArgumentNullException("reader");
      this._onlyDetectEncoding = false;
      this.Openednodes = !this.OptionCheckSyntax ? (Dictionary<int, HtmlNode>) null : new Dictionary<int, HtmlNode>();
      this.Nodesid = !this.OptionUseIdAttribute ? (Dictionary<string, HtmlNode>) null : new Dictionary<string, HtmlNode>();
      StreamReader streamReader = reader as StreamReader;
      if (streamReader != null)
      {
        try
        {
          streamReader.Peek();
        }
        catch (Exception ex)
        {
        }
        this._streamencoding = streamReader.CurrentEncoding;
      }
      else
        this._streamencoding = (Encoding) null;
      this._declaredencoding = (Encoding) null;
      this.Text = reader.ReadToEnd();
      this._documentnode = this.CreateNode(HtmlNodeType.Document, 0);
      this.Parse();
      if (!this.OptionCheckSyntax || this.Openednodes == null)
        return;
      foreach (HtmlNode htmlNode in this.Openednodes.Values)
      {
        if (htmlNode._starttag)
        {
          string sourceText;
          if (this.OptionExtractErrorSourceText)
          {
            sourceText = htmlNode.OuterHtml;
            if (sourceText.Length > this.OptionExtractErrorSourceTextMaxLength)
              sourceText = sourceText.Substring(0, this.OptionExtractErrorSourceTextMaxLength);
          }
          else
            sourceText = string.Empty;
          this.AddError(HtmlParseErrorCode.TagNotClosed, htmlNode._line, htmlNode._lineposition, htmlNode._streamposition, sourceText, "End tag </" + htmlNode.Name + "> was not found");
        }
      }
      this.Openednodes.Clear();
    }

    /// <summary>
    /// Loads the HTML document from the specified string.
    /// 
    /// </summary>
    /// <param name="html">String containing the HTML document to load. May not be null.</param>
    public void LoadHtml(string html)
    {
      if (html == null)
        throw new ArgumentNullException("html");
      using (StringReader stringReader = new StringReader(html))
        this.Load((TextReader) stringReader);
    }

    /// <summary>
    /// Saves the HTML document to the specified stream.
    /// 
    /// </summary>
    /// <param name="outStream">The stream to which you want to save.</param>
    public void Save(Stream outStream)
    {
      this.Save(new StreamWriter(outStream, this.GetOutEncoding()));
    }

    /// <summary>
    /// Saves the HTML document to the specified stream.
    /// 
    /// </summary>
    /// <param name="outStream">The stream to which you want to save. May not be null.</param><param name="encoding">The character encoding to use. May not be null.</param>
    public void Save(Stream outStream, Encoding encoding)
    {
      if (outStream == null)
        throw new ArgumentNullException("outStream");
      if (encoding == null)
        throw new ArgumentNullException("encoding");
      this.Save(new StreamWriter(outStream, encoding));
    }

    /// <summary>
    /// Saves the HTML document to the specified StreamWriter.
    /// 
    /// </summary>
    /// <param name="writer">The StreamWriter to which you want to save.</param>
    public void Save(StreamWriter writer)
    {
      this.Save((TextWriter) writer);
    }

    /// <summary>
    /// Saves the HTML document to the specified TextWriter.
    /// 
    /// </summary>
    /// <param name="writer">The TextWriter to which you want to save. May not be null.</param>
    public void Save(TextWriter writer)
    {
      if (writer == null)
        throw new ArgumentNullException("writer");
      this.DocumentNode.WriteTo(writer);
      writer.Flush();
    }

    /// <summary>
    /// Saves the HTML document to the specified XmlWriter.
    /// 
    /// </summary>
    /// <param name="writer">The XmlWriter to which you want to save.</param>
    public void Save(XmlWriter writer)
    {
      this.DocumentNode.WriteTo(writer);
      writer.Flush();
    }

    internal HtmlAttribute CreateAttribute()
    {
      return new HtmlAttribute(this);
    }

    internal HtmlNode CreateNode(HtmlNodeType type)
    {
      return this.CreateNode(type, -1);
    }

    internal HtmlNode CreateNode(HtmlNodeType type, int index)
    {
      switch (type)
      {
        case HtmlNodeType.Comment:
          return (HtmlNode) new HtmlCommentNode(this, index);
        case HtmlNodeType.Text:
          return (HtmlNode) new HtmlTextNode(this, index);
        default:
          return new HtmlNode(type, this, index);
      }
    }

    internal Encoding GetOutEncoding()
    {
      return this._declaredencoding ?? this._streamencoding ?? this.OptionDefaultStreamEncoding;
    }

    internal HtmlNode GetXmlDeclaration()
    {
      if (!this._documentnode.HasChildNodes)
        return (HtmlNode) null;
      foreach (HtmlNode htmlNode in (IEnumerable<HtmlNode>) this._documentnode._childnodes)
      {
        if (htmlNode.Name == "?xml")
          return htmlNode;
      }
      return (HtmlNode) null;
    }

    internal void SetIdForNode(HtmlNode node, string id)
    {
      if (!this.OptionUseIdAttribute || this.Nodesid == null || id == null)
        return;
      if (node == null)
        this.Nodesid.Remove(id.ToLower());
      else
        this.Nodesid[id.ToLower()] = node;
    }

    internal void UpdateLastParentNode()
    {
      do
      {
        if (this._lastparentnode.Closed)
          this._lastparentnode = this._lastparentnode.ParentNode;
      }
      while (this._lastparentnode != null && this._lastparentnode.Closed);
      if (this._lastparentnode != null)
        return;
      this._lastparentnode = this._documentnode;
    }

    private void AddError(HtmlParseErrorCode code, int line, int linePosition, int streamPosition, string sourceText, string reason)
    {
      this._parseerrors.Add(new HtmlParseError(code, line, linePosition, streamPosition, sourceText, reason));
    }


    private void CloseCurrentNode()
    {
      if (this._currentnode.Closed)
        return;
      bool flag = false;
      HtmlNode dictionaryValueOrNull = Utilities.GetDictionaryValueOrNull<string, HtmlNode>(this.Lastnodes, this._currentnode.Name);
      if (dictionaryValueOrNull == null)
      {
        if (HtmlNode.IsClosedElement(this._currentnode.Name))
        {
          this._currentnode.CloseNode(this._currentnode);
          if (this._lastparentnode != null)
          {
            HtmlNode htmlNode1 = (HtmlNode) null;
            Stack<HtmlNode> stack = new Stack<HtmlNode>();
            for (HtmlNode htmlNode2 = this._lastparentnode.LastChild; htmlNode2 != null; htmlNode2 = htmlNode2.PreviousSibling)
            {
              if (htmlNode2.Name == this._currentnode.Name && !htmlNode2.HasChildNodes)
              {
                htmlNode1 = htmlNode2;
                break;
              }
              stack.Push(htmlNode2);
            }
            if (htmlNode1 != null)
            {
              while (stack.Count != 0)
              {
                HtmlNode htmlNode2 = stack.Pop();
                this._lastparentnode.RemoveChild(htmlNode2);
                htmlNode1.AppendChild(htmlNode2);
              }
            }
            else
              this._lastparentnode.AppendChild(this._currentnode);
          }
        }
        else if (HtmlNode.CanOverlapElement(this._currentnode.Name))
        {
          HtmlNode node = this.CreateNode(HtmlNodeType.Text, this._currentnode._outerstartindex);
          node._outerlength = this._currentnode._outerlength;
          ((HtmlTextNode) node).Text = ((HtmlTextNode) node).Text.ToLower();
          if (this._lastparentnode != null)
            this._lastparentnode.AppendChild(node);
        }
        else if (HtmlNode.IsEmptyElement(this._currentnode.Name))
        {
          this.AddError(HtmlParseErrorCode.EndTagNotRequired, this._currentnode._line, this._currentnode._lineposition, this._currentnode._streamposition, this._currentnode.OuterHtml, "End tag </" + this._currentnode.Name + "> is not required");
        }
        else
        {
          this.AddError(HtmlParseErrorCode.TagNotOpened, this._currentnode._line, this._currentnode._lineposition, this._currentnode._streamposition, this._currentnode.OuterHtml, "Start tag <" + this._currentnode.Name + "> was not found");
          flag = true;
        }
      }
      else
      {
        if (this.OptionFixNestedTags && this.FindResetterNodes(dictionaryValueOrNull, this.GetResetters(this._currentnode.Name)))
        {
          this.AddError(HtmlParseErrorCode.EndTagInvalidHere, this._currentnode._line, this._currentnode._lineposition, this._currentnode._streamposition, this._currentnode.OuterHtml, "End tag </" + this._currentnode.Name + "> invalid here");
          flag = true;
        }
        if (!flag)
        {
          this.Lastnodes[this._currentnode.Name] = dictionaryValueOrNull._prevwithsamename;
          dictionaryValueOrNull.CloseNode(this._currentnode);
        }
      }
      if (flag || this._lastparentnode == null || HtmlNode.IsClosedElement(this._currentnode.Name) && !this._currentnode._starttag)
        return;
      this.UpdateLastParentNode();
    }

    private string CurrentNodeName()
    {
      return this.Text.Substring(this._currentnode._namestartindex, this._currentnode._namelength);
    }

    private void DecrementPosition()
    {
      --this._index;
      if (this._lineposition == 1)
      {
        this._lineposition = this._maxlineposition;
        --this._line;
      }
      else
        --this._lineposition;
    }

    private HtmlNode FindResetterNode(HtmlNode node, string name)
    {
      HtmlNode dictionaryValueOrNull = Utilities.GetDictionaryValueOrNull<string, HtmlNode>(this.Lastnodes, name);
      if (dictionaryValueOrNull == null)
        return (HtmlNode) null;
      if (dictionaryValueOrNull.Closed)
        return (HtmlNode) null;
      if (dictionaryValueOrNull._streamposition < node._streamposition)
        return (HtmlNode) null;
      return dictionaryValueOrNull;
    }

    private bool FindResetterNodes(HtmlNode node, string[] names)
    {
      if (names == null)
        return false;
      for (int index = 0; index < names.Length; ++index)
      {
        if (this.FindResetterNode(node, names[index]) != null)
          return true;
      }
      return false;
    }

    private void FixNestedTag(string name, string[] resetters)
    {
      if (resetters == null)
        return;
      HtmlNode dictionaryValueOrNull = Utilities.GetDictionaryValueOrNull<string, HtmlNode>(this.Lastnodes, this._currentnode.Name);
      if (dictionaryValueOrNull == null || this.Lastnodes[name].Closed || this.FindResetterNodes(dictionaryValueOrNull, resetters))
        return;
      HtmlNode endnode = new HtmlNode(dictionaryValueOrNull.NodeType, this, -1);
      endnode._endnode = endnode;
      dictionaryValueOrNull.CloseNode(endnode);
    }

    private void FixNestedTags()
    {
      if (!this._currentnode._starttag)
        return;
      string name = this.CurrentNodeName();
      this.FixNestedTag(name, this.GetResetters(name));
    }

    private string[] GetResetters(string name)
    {
      switch (name)
      {
        case "li":
          return new string[1]
          {
            "ul"
          };
        case "tr":
          return new string[1]
          {
            "table"
          };
        case "th":
        case "td":
          return new string[2]
          {
            "tr",
            "table"
          };
        default:
          return (string[]) null;
      }
    }

    private void IncrementPosition()
    {
      if (this._crc32 != null)
      {
        int num = (int) this._crc32.AddToCRC32(this._c);
      }
      ++this._index;
      this._maxlineposition = this._lineposition;
      if (this._c == 10)
      {
        this._lineposition = 1;
        ++this._line;
      }
      else
        ++this._lineposition;
    }

    private bool NewCheck()
    {
      if (this._c != 60)
        return false;
      if (this._index < this.Text.Length && (int) this.Text[this._index] == 37)
      {
        switch (this._state)
        {
          case HtmlDocument.ParseState.WhichTag:
            this.PushNodeNameStart(true, this._index - 1);
            this._state = HtmlDocument.ParseState.Tag;
            break;
          case HtmlDocument.ParseState.BetweenAttributes:
            this.PushAttributeNameStart(this._index - 1);
            break;
          case HtmlDocument.ParseState.AttributeAfterEquals:
            this.PushAttributeValueStart(this._index - 1);
            break;
        }
        this._oldstate = this._state;
        this._state = HtmlDocument.ParseState.ServerSideCode;
        return true;
      }
      if (!this.PushNodeEnd(this._index - 1, true))
      {
        this._index = this.Text.Length;
        return true;
      }
      this._state = HtmlDocument.ParseState.WhichTag;
      if (this._index - 1 <= this.Text.Length - 2 && (int) this.Text[this._index] == 33)
      {
        this.PushNodeStart(HtmlNodeType.Comment, this._index - 1);
        this.PushNodeNameStart(true, this._index);
        this.PushNodeNameEnd(this._index + 1);
        this._state = HtmlDocument.ParseState.Comment;
        if (this._index < this.Text.Length - 2)
          this._fullcomment = (int) this.Text[this._index + 1] == 45 && (int) this.Text[this._index + 2] == 45;
        return true;
      }
      this.PushNodeStart(HtmlNodeType.Element, this._index - 1);
      return true;
    }

    private void Parse()
    {
      int num = 0;
      if (this.OptionComputeChecksum)
        this._crc32 = new Crc32();
      this.Lastnodes = new Dictionary<string, HtmlNode>();
      this._c = 0;
      this._fullcomment = false;
      this._parseerrors = new List<HtmlParseError>();
      this._line = 1;
      this._lineposition = 1;
      this._maxlineposition = 1;
      this._state = HtmlDocument.ParseState.Text;
      this._oldstate = this._state;
      this._documentnode._innerlength = this.Text.Length;
      this._documentnode._outerlength = this.Text.Length;
      this._remainderOffset = this.Text.Length;
      this._lastparentnode = this._documentnode;
      this._currentnode = this.CreateNode(HtmlNodeType.Text, 0);
      this._currentattribute = (HtmlAttribute) null;
      this._index = 0;
      this.PushNodeStart(HtmlNodeType.Text, 0);
      while (this._index < this.Text.Length)
      {
        this._c = (int) this.Text[this._index];
        this.IncrementPosition();
        switch (this._state)
        {
          case HtmlDocument.ParseState.Text:
            if (!this.NewCheck())
              continue;
            continue;
          case HtmlDocument.ParseState.WhichTag:
            if (!this.NewCheck())
            {
              if (this._c == 47)
              {
                this.PushNodeNameStart(false, this._index);
              }
              else
              {
                this.PushNodeNameStart(true, this._index - 1);
                this.DecrementPosition();
              }
              this._state = HtmlDocument.ParseState.Tag;
              continue;
            }
            continue;
          case HtmlDocument.ParseState.Tag:
            if (!this.NewCheck())
            {
              if (HtmlDocument.IsWhiteSpace(this._c))
              {
                this.PushNodeNameEnd(this._index - 1);
                if (this._state == HtmlDocument.ParseState.Tag)
                {
                  this._state = HtmlDocument.ParseState.BetweenAttributes;
                  continue;
                }
                continue;
              }
              if (this._c == 47)
              {
                this.PushNodeNameEnd(this._index - 1);
                if (this._state == HtmlDocument.ParseState.Tag)
                {
                  this._state = HtmlDocument.ParseState.EmptyTag;
                  continue;
                }
                continue;
              }
              if (this._c == 62)
              {
                this.PushNodeNameEnd(this._index - 1);
                if (this._state == HtmlDocument.ParseState.Tag)
                {
                  if (!this.PushNodeEnd(this._index, false))
                  {
                    this._index = this.Text.Length;
                    continue;
                  }
                  if (this._state == HtmlDocument.ParseState.Tag)
                  {
                    this._state = HtmlDocument.ParseState.Text;
                    this.PushNodeStart(HtmlNodeType.Text, this._index);
                    continue;
                  }
                  continue;
                }
                continue;
              }
              continue;
            }
            continue;
          case HtmlDocument.ParseState.BetweenAttributes:
            if (!this.NewCheck() && !HtmlDocument.IsWhiteSpace(this._c))
            {
              if (this._c == 47 || this._c == 63)
              {
                this._state = HtmlDocument.ParseState.EmptyTag;
                continue;
              }
              if (this._c == 62)
              {
                if (!this.PushNodeEnd(this._index, false))
                {
                  this._index = this.Text.Length;
                  continue;
                }
                if (this._state == HtmlDocument.ParseState.BetweenAttributes)
                {
                  this._state = HtmlDocument.ParseState.Text;
                  this.PushNodeStart(HtmlNodeType.Text, this._index);
                  continue;
                }
                continue;
              }
              this.PushAttributeNameStart(this._index - 1);
              this._state = HtmlDocument.ParseState.AttributeName;
              continue;
            }
            continue;
          case HtmlDocument.ParseState.EmptyTag:
            if (!this.NewCheck())
            {
              if (this._c == 62)
              {
                if (!this.PushNodeEnd(this._index, true))
                {
                  this._index = this.Text.Length;
                  continue;
                }
                if (this._state == HtmlDocument.ParseState.EmptyTag)
                {
                  this._state = HtmlDocument.ParseState.Text;
                  this.PushNodeStart(HtmlNodeType.Text, this._index);
                  continue;
                }
                continue;
              }
              this._state = HtmlDocument.ParseState.BetweenAttributes;
              continue;
            }
            continue;
          case HtmlDocument.ParseState.AttributeName:
            if (!this.NewCheck())
            {
              if (HtmlDocument.IsWhiteSpace(this._c))
              {
                this.PushAttributeNameEnd(this._index - 1);
                this._state = HtmlDocument.ParseState.AttributeBeforeEquals;
                continue;
              }
              if (this._c == 61)
              {
                this.PushAttributeNameEnd(this._index - 1);
                this._state = HtmlDocument.ParseState.AttributeAfterEquals;
                continue;
              }
              if (this._c == 62)
              {
                this.PushAttributeNameEnd(this._index - 1);
                if (!this.PushNodeEnd(this._index, false))
                {
                  this._index = this.Text.Length;
                  continue;
                }
                if (this._state == HtmlDocument.ParseState.AttributeName)
                {
                  this._state = HtmlDocument.ParseState.Text;
                  this.PushNodeStart(HtmlNodeType.Text, this._index);
                  continue;
                }
                continue;
              }
              continue;
            }
            continue;
          case HtmlDocument.ParseState.AttributeBeforeEquals:
            if (!this.NewCheck() && !HtmlDocument.IsWhiteSpace(this._c))
            {
              if (this._c == 62)
              {
                if (!this.PushNodeEnd(this._index, false))
                {
                  this._index = this.Text.Length;
                  continue;
                }
                if (this._state == HtmlDocument.ParseState.AttributeBeforeEquals)
                {
                  this._state = HtmlDocument.ParseState.Text;
                  this.PushNodeStart(HtmlNodeType.Text, this._index);
                  continue;
                }
                continue;
              }
              if (this._c == 61)
              {
                this._state = HtmlDocument.ParseState.AttributeAfterEquals;
                continue;
              }
              this._state = HtmlDocument.ParseState.BetweenAttributes;
              this.DecrementPosition();
              continue;
            }
            continue;
          case HtmlDocument.ParseState.AttributeAfterEquals:
            if (!this.NewCheck() && !HtmlDocument.IsWhiteSpace(this._c))
            {
              if (this._c == 39 || this._c == 34)
              {
                this._state = HtmlDocument.ParseState.QuotedAttributeValue;
                this.PushAttributeValueStart(this._index, this._c);
                num = this._c;
                continue;
              }
              if (this._c == 62)
              {
                if (!this.PushNodeEnd(this._index, false))
                {
                  this._index = this.Text.Length;
                  continue;
                }
                if (this._state == HtmlDocument.ParseState.AttributeAfterEquals)
                {
                  this._state = HtmlDocument.ParseState.Text;
                  this.PushNodeStart(HtmlNodeType.Text, this._index);
                  continue;
                }
                continue;
              }
              this.PushAttributeValueStart(this._index - 1);
              this._state = HtmlDocument.ParseState.AttributeValue;
              continue;
            }
            continue;
          case HtmlDocument.ParseState.AttributeValue:
            if (!this.NewCheck())
            {
              if (HtmlDocument.IsWhiteSpace(this._c))
              {
                this.PushAttributeValueEnd(this._index - 1);
                this._state = HtmlDocument.ParseState.BetweenAttributes;
                continue;
              }
              if (this._c == 62)
              {
                this.PushAttributeValueEnd(this._index - 1);
                if (!this.PushNodeEnd(this._index, false))
                {
                  this._index = this.Text.Length;
                  continue;
                }
                if (this._state == HtmlDocument.ParseState.AttributeValue)
                {
                  this._state = HtmlDocument.ParseState.Text;
                  this.PushNodeStart(HtmlNodeType.Text, this._index);
                  continue;
                }
                continue;
              }
              continue;
            }
            continue;
          case HtmlDocument.ParseState.Comment:
            if (this._c == 62 && (!this._fullcomment || (int) this.Text[this._index - 2] == 45 && (int) this.Text[this._index - 3] == 45))
            {
              if (!this.PushNodeEnd(this._index, false))
              {
                this._index = this.Text.Length;
                continue;
              }
              this._state = HtmlDocument.ParseState.Text;
              this.PushNodeStart(HtmlNodeType.Text, this._index);
              continue;
            }
            continue;
          case HtmlDocument.ParseState.QuotedAttributeValue:
            if (this._c == num)
            {
              this.PushAttributeValueEnd(this._index - 1);
              this._state = HtmlDocument.ParseState.BetweenAttributes;
              continue;
            }
            if (this._c == 60 && this._index < this.Text.Length && (int) this.Text[this._index] == 37)
            {
              this._oldstate = this._state;
              this._state = HtmlDocument.ParseState.ServerSideCode;
              continue;
            }
            continue;
          case HtmlDocument.ParseState.ServerSideCode:
            if (this._c == 37 && this._index < this.Text.Length && (int) this.Text[this._index] == 62)
            {
              switch (this._oldstate)
              {
                case HtmlDocument.ParseState.BetweenAttributes:
                  this.PushAttributeNameEnd(this._index + 1);
                  this._state = HtmlDocument.ParseState.BetweenAttributes;
                  break;
                case HtmlDocument.ParseState.AttributeAfterEquals:
                  this._state = HtmlDocument.ParseState.AttributeValue;
                  break;
                default:
                  this._state = this._oldstate;
                  break;
              }
              this.IncrementPosition();
              continue;
            }
            continue;
          case HtmlDocument.ParseState.PcData:
            if (this._currentnode._namelength + 3 <= this.Text.Length - (this._index - 1) && string.Compare(this.Text.Substring(this._index - 1, this._currentnode._namelength + 2), "</" + this._currentnode.Name, StringComparison.OrdinalIgnoreCase) == 0)
            {
              int c = (int) this.Text[this._index - 1 + 2 + this._currentnode.Name.Length];
              if (c == 62 || HtmlDocument.IsWhiteSpace(c))
              {
                HtmlNode node = this.CreateNode(HtmlNodeType.Text, this._currentnode._outerstartindex + this._currentnode._outerlength);
                node._outerlength = this._index - 1 - node._outerstartindex;
                this._currentnode.AppendChild(node);
                this.PushNodeStart(HtmlNodeType.Element, this._index - 1);
                this.PushNodeNameStart(false, this._index - 1 + 2);
                this._state = HtmlDocument.ParseState.Tag;
                this.IncrementPosition();
                continue;
              }
              continue;
            }
            continue;
          default:
            continue;
        }
      }
      if (this._currentnode._namestartindex > 0)
        this.PushNodeNameEnd(this._index);
      this.PushNodeEnd(this._index, false);
      this.Lastnodes.Clear();
    }

    private void PushAttributeNameEnd(int index)
    {
      this._currentattribute._namelength = index - this._currentattribute._namestartindex;
      this._currentnode.Attributes.Append(this._currentattribute);
    }

    private void PushAttributeNameStart(int index)
    {
      this._currentattribute = this.CreateAttribute();
      this._currentattribute._namestartindex = index;
      this._currentattribute.Line = this._line;
      this._currentattribute._lineposition = this._lineposition;
      this._currentattribute._streamposition = index;
    }

    private void PushAttributeValueEnd(int index)
    {
      this._currentattribute._valuelength = index - this._currentattribute._valuestartindex;
    }

    private void PushAttributeValueStart(int index)
    {
      this.PushAttributeValueStart(index, 0);
    }

    private void PushAttributeValueStart(int index, int quote)
    {
      this._currentattribute._valuestartindex = index;
      if (quote != 39)
        return;
      this._currentattribute.QuoteType = AttributeValueQuote.SingleQuote;
    }

    private bool PushNodeEnd(int index, bool close)
    {
      this._currentnode._outerlength = index - this._currentnode._outerstartindex;
      if (this._currentnode._nodetype == HtmlNodeType.Text || this._currentnode._nodetype == HtmlNodeType.Comment)
      {
        if (this._currentnode._outerlength > 0)
        {
          this._currentnode._innerlength = this._currentnode._outerlength;
          this._currentnode._innerstartindex = this._currentnode._outerstartindex;
          if (this._lastparentnode != null)
            this._lastparentnode.AppendChild(this._currentnode);
        }
      }
      else if (this._currentnode._starttag && this._lastparentnode != this._currentnode)
      {
        if (this._lastparentnode != null)
          this._lastparentnode.AppendChild(this._currentnode);
        this.ReadDocumentEncoding(this._currentnode);
        this._currentnode._prevwithsamename = Utilities.GetDictionaryValueOrNull<string, HtmlNode>(this.Lastnodes, this._currentnode.Name);
        this.Lastnodes[this._currentnode.Name] = this._currentnode;
        if (this._currentnode.NodeType == HtmlNodeType.Document || this._currentnode.NodeType == HtmlNodeType.Element)
          this._lastparentnode = this._currentnode;
        if (HtmlNode.IsCDataElement(this.CurrentNodeName()))
        {
          this._state = HtmlDocument.ParseState.PcData;
          return true;
        }
        if (HtmlNode.IsClosedElement(this._currentnode.Name) || HtmlNode.IsEmptyElement(this._currentnode.Name))
          close = true;
      }
      if (close || !this._currentnode._starttag)
      {
        if (this.OptionStopperNodeName != null && this._remainder == null && string.Compare(this._currentnode.Name, this.OptionStopperNodeName, StringComparison.OrdinalIgnoreCase) == 0)
        {
          this._remainderOffset = index;
          this._remainder = this.Text.Substring(this._remainderOffset);
          this.CloseCurrentNode();
          return false;
        }
        this.CloseCurrentNode();
      }
      return true;
    }

    private void PushNodeNameEnd(int index)
    {
      this._currentnode._namelength = index - this._currentnode._namestartindex;
      if (!this.OptionFixNestedTags)
        return;
      this.FixNestedTags();
    }

    private void PushNodeNameStart(bool starttag, int index)
    {
      this._currentnode._starttag = starttag;
      this._currentnode._namestartindex = index;
    }

    private void PushNodeStart(HtmlNodeType type, int index)
    {
      this._currentnode = this.CreateNode(type, index);
      this._currentnode._line = this._line;
      this._currentnode._lineposition = this._lineposition;
      if (type == HtmlNodeType.Element)
        --this._currentnode._lineposition;
      this._currentnode._streamposition = index;
    }

    private void ReadDocumentEncoding(HtmlNode node)
    {
      if (!this.OptionReadEncoding || node._namelength != 4 || node.Name != "meta")
        return;
      HtmlAttribute htmlAttribute1 = node.Attributes["http-equiv"];
      if (htmlAttribute1 == null || string.Compare(htmlAttribute1.Value, "content-type", StringComparison.OrdinalIgnoreCase) != 0)
        return;
      HtmlAttribute htmlAttribute2 = node.Attributes["content"];
      if (htmlAttribute2 == null)
        return;
      string str = NameValuePairList.GetNameValuePairsValue(htmlAttribute2.Value, "charset");
      if (string.IsNullOrEmpty(str))
        return;
      if (string.Equals(str, "utf8", StringComparison.OrdinalIgnoreCase))
        str = "utf-8";
      try
      {
        this._declaredencoding = Encoding.GetEncoding(str);
      }
      catch (ArgumentException ex)
      {
        this._declaredencoding = (Encoding) null;
      }
      if (this._onlyDetectEncoding)
        throw new EncodingFoundException(this._declaredencoding);
      if (this._streamencoding == null || this._declaredencoding == null || this._declaredencoding.WindowsCodePage == this._streamencoding.WindowsCodePage)
        return;
      this.AddError(HtmlParseErrorCode.CharsetMismatch, this._line, this._lineposition, this._index, node.OuterHtml, "Encoding mismatch between StreamEncoding: " + this._streamencoding.WebName + " and DeclaredEncoding: " + this._declaredencoding.WebName);
    }

    private enum ParseState
    {
      Text,
      WhichTag,
      Tag,
      BetweenAttributes,
      EmptyTag,
      AttributeName,
      AttributeBeforeEquals,
      AttributeAfterEquals,
      AttributeValue,
      Comment,
      QuotedAttributeValue,
      ServerSideCode,
      PcData,
    }
  }
}
