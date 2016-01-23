// Decompiled with JetBrains decompiler
// Type: HtmlAgilityPack.MixedCodeDocument
// Assembly: HtmlAgilityPack, Version=1.4.6.0, Culture=neutral, PublicKeyToken=bd319b19eaf3b43a
// MVID: 33288599-2B93-45A3-99F5-D89D6188B861
// Assembly location: C:\Users\kiril_000\Downloads\HtmlAgilityPack.1.4.6\Net45\HtmlAgilityPack.dll

using System;
using System.IO;
using System.Text;

namespace HtmlAgilityPack
{
  /// <summary>
  /// Represents a document with mixed code and text. ASP, ASPX, JSP, are good example of such documents.
  /// 
  /// </summary>
  public class MixedCodeDocument
  {
    /// <summary>
    /// Gets or sets the token representing code end.
    /// 
    /// </summary>
    public string TokenCodeEnd = "%>";
    /// <summary>
    /// Gets or sets the token representing code start.
    /// 
    /// </summary>
    public string TokenCodeStart = "<%";
    /// <summary>
    /// Gets or sets the token representing code directive.
    /// 
    /// </summary>
    public string TokenDirective = "@";
    /// <summary>
    /// Gets or sets the token representing response write directive.
    /// 
    /// </summary>
    public string TokenResponseWrite = "Response.Write ";
    private string TokenTextBlock = "TextBlock({0})";
    private int _c;
    internal MixedCodeDocumentFragmentList _codefragments;
    private MixedCodeDocumentFragment _currentfragment;
    internal MixedCodeDocumentFragmentList _fragments;
    private int _index;
    private int _line;
    private int _lineposition;
    private MixedCodeDocument.ParseState _state;
    private Encoding _streamencoding;
    internal string _text;
    internal MixedCodeDocumentFragmentList _textfragments;

    /// <summary>
    /// Gets the code represented by the mixed code document seen as a template.
    /// 
    /// </summary>
    public string Code
    {
      get
      {
        string str = "";
        int num = 0;
        foreach (MixedCodeDocumentFragment documentFragment in this._fragments)
        {
          switch (documentFragment._type)
          {
            case MixedCodeDocumentFragmentType.Code:
              str = str + ((MixedCodeDocumentCodeFragment) documentFragment).Code + "\n";
              continue;
            case MixedCodeDocumentFragmentType.Text:
              str = str + this.TokenResponseWrite + string.Format(this.TokenTextBlock, (object) num) + "\n";
              ++num;
              continue;
            default:
              continue;
          }
        }
        return str;
      }
    }

    /// <summary>
    /// Gets the list of code fragments in the document.
    /// 
    /// </summary>
    public MixedCodeDocumentFragmentList CodeFragments
    {
      get
      {
        return this._codefragments;
      }
    }

    /// <summary>
    /// Gets the list of all fragments in the document.
    /// 
    /// </summary>
    public MixedCodeDocumentFragmentList Fragments
    {
      get
      {
        return this._fragments;
      }
    }

    /// <summary>
    /// Gets the encoding of the stream used to read the document.
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
    /// Gets the list of text fragments in the document.
    /// 
    /// </summary>
    public MixedCodeDocumentFragmentList TextFragments
    {
      get
      {
        return this._textfragments;
      }
    }

    /// <summary>
    /// Creates a mixed code document instance.
    /// 
    /// </summary>
    public MixedCodeDocument()
    {
      this._codefragments = new MixedCodeDocumentFragmentList(this);
      this._textfragments = new MixedCodeDocumentFragmentList(this);
      this._fragments = new MixedCodeDocumentFragmentList(this);
    }

    /// <summary>
    /// Create a code fragment instances.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// The newly created code fragment instance.
    /// </returns>
    public MixedCodeDocumentCodeFragment CreateCodeFragment()
    {
      return (MixedCodeDocumentCodeFragment) this.CreateFragment(MixedCodeDocumentFragmentType.Code);
    }

    /// <summary>
    /// Create a text fragment instances.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// The newly created text fragment instance.
    /// </returns>
    public MixedCodeDocumentTextFragment CreateTextFragment()
    {
      return (MixedCodeDocumentTextFragment) this.CreateFragment(MixedCodeDocumentFragmentType.Text);
    }

    /// <summary>
    /// Loads a mixed code document from a stream.
    /// 
    /// </summary>
    /// <param name="stream">The input stream.</param>
    public void Load(Stream stream)
    {
      this.Load((TextReader) new StreamReader(stream));
    }

    /// <summary>
    /// Loads a mixed code document from a stream.
    /// 
    /// </summary>
    /// <param name="stream">The input stream.</param><param name="detectEncodingFromByteOrderMarks">Indicates whether to look for byte order marks at the beginning of the file.</param>
    public void Load(Stream stream, bool detectEncodingFromByteOrderMarks)
    {
      this.Load((TextReader) new StreamReader(stream, detectEncodingFromByteOrderMarks));
    }

    /// <summary>
    /// Loads a mixed code document from a stream.
    /// 
    /// </summary>
    /// <param name="stream">The input stream.</param><param name="encoding">The character encoding to use.</param>
    public void Load(Stream stream, Encoding encoding)
    {
      this.Load((TextReader) new StreamReader(stream, encoding));
    }

    /// <summary>
    /// Loads a mixed code document from a stream.
    /// 
    /// </summary>
    /// <param name="stream">The input stream.</param><param name="encoding">The character encoding to use.</param><param name="detectEncodingFromByteOrderMarks">Indicates whether to look for byte order marks at the beginning of the file.</param>
    public void Load(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks)
    {
      this.Load((TextReader) new StreamReader(stream, encoding, detectEncodingFromByteOrderMarks));
    }

    /// <summary>
    /// Loads a mixed code document from a stream.
    /// 
    /// </summary>
    /// <param name="stream">The input stream.</param><param name="encoding">The character encoding to use.</param><param name="detectEncodingFromByteOrderMarks">Indicates whether to look for byte order marks at the beginning of the file.</param><param name="buffersize">The minimum buffer size.</param>
    public void Load(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int buffersize)
    {
      this.Load((TextReader) new StreamReader(stream, encoding, detectEncodingFromByteOrderMarks, buffersize));
    }

    /// <summary>
    /// Loads a mixed code document from a file.
    /// 
    /// </summary>
    /// <param name="path">The complete file path to be read.</param>
    public void Load(string path)
    {
      this.Load((TextReader) new StreamReader(path));
    }

    /// <summary>
    /// Loads a mixed code document from a file.
    /// 
    /// </summary>
    /// <param name="path">The complete file path to be read.</param><param name="detectEncodingFromByteOrderMarks">Indicates whether to look for byte order marks at the beginning of the file.</param>
    public void Load(string path, bool detectEncodingFromByteOrderMarks)
    {
      this.Load((TextReader) new StreamReader(path, detectEncodingFromByteOrderMarks));
    }

    /// <summary>
    /// Loads a mixed code document from a file.
    /// 
    /// </summary>
    /// <param name="path">The complete file path to be read.</param><param name="encoding">The character encoding to use.</param>
    public void Load(string path, Encoding encoding)
    {
      this.Load((TextReader) new StreamReader(path, encoding));
    }

    /// <summary>
    /// Loads a mixed code document from a file.
    /// 
    /// </summary>
    /// <param name="path">The complete file path to be read.</param><param name="encoding">The character encoding to use.</param><param name="detectEncodingFromByteOrderMarks">Indicates whether to look for byte order marks at the beginning of the file.</param>
    public void Load(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks)
    {
      this.Load((TextReader) new StreamReader(path, encoding, detectEncodingFromByteOrderMarks));
    }

    /// <summary>
    /// Loads a mixed code document from a file.
    /// 
    /// </summary>
    /// <param name="path">The complete file path to be read.</param><param name="encoding">The character encoding to use.</param><param name="detectEncodingFromByteOrderMarks">Indicates whether to look for byte order marks at the beginning of the file.</param><param name="buffersize">The minimum buffer size.</param>
    public void Load(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks, int buffersize)
    {
      this.Load((TextReader) new StreamReader(path, encoding, detectEncodingFromByteOrderMarks, buffersize));
    }

    /// <summary>
    /// Loads the mixed code document from the specified TextReader.
    /// 
    /// </summary>
    /// <param name="reader">The TextReader used to feed the HTML data into the document.</param>
    public void Load(TextReader reader)
    {
      this._codefragments.Clear();
      this._textfragments.Clear();
      StreamReader streamReader = reader as StreamReader;
      if (streamReader != null)
        this._streamencoding = streamReader.CurrentEncoding;
      this._text = reader.ReadToEnd();
      reader.Close();
      this.Parse();
    }

    /// <summary>
    /// Loads a mixed document from a text
    /// 
    /// </summary>
    /// <param name="html">The text to load.</param>
    public void LoadHtml(string html)
    {
      this.Load((TextReader) new StringReader(html));
    }

    /// <summary>
    /// Saves the mixed document to the specified stream.
    /// 
    /// </summary>
    /// <param name="outStream">The stream to which you want to save.</param>
    public void Save(Stream outStream)
    {
      this.Save(new StreamWriter(outStream, this.GetOutEncoding()));
    }

    /// <summary>
    /// Saves the mixed document to the specified stream.
    /// 
    /// </summary>
    /// <param name="outStream">The stream to which you want to save.</param><param name="encoding">The character encoding to use.</param>
    public void Save(Stream outStream, Encoding encoding)
    {
      this.Save(new StreamWriter(outStream, encoding));
    }

    /// <summary>
    /// Saves the mixed document to the specified file.
    /// 
    /// </summary>
    /// <param name="filename">The location of the file where you want to save the document.</param>
    public void Save(string filename)
    {
      this.Save(new StreamWriter(filename, false, this.GetOutEncoding()));
    }

    /// <summary>
    /// Saves the mixed document to the specified file.
    /// 
    /// </summary>
    /// <param name="filename">The location of the file where you want to save the document.</param><param name="encoding">The character encoding to use.</param>
    public void Save(string filename, Encoding encoding)
    {
      this.Save(new StreamWriter(filename, false, encoding));
    }

    /// <summary>
    /// Saves the mixed document to the specified StreamWriter.
    /// 
    /// </summary>
    /// <param name="writer">The StreamWriter to which you want to save.</param>
    public void Save(StreamWriter writer)
    {
      this.Save((TextWriter) writer);
    }

    /// <summary>
    /// Saves the mixed document to the specified TextWriter.
    /// 
    /// </summary>
    /// <param name="writer">The TextWriter to which you want to save.</param>
    public void Save(TextWriter writer)
    {
      writer.Flush();
    }

    internal MixedCodeDocumentFragment CreateFragment(MixedCodeDocumentFragmentType type)
    {
      switch (type)
      {
        case MixedCodeDocumentFragmentType.Code:
          return (MixedCodeDocumentFragment) new MixedCodeDocumentCodeFragment(this);
        case MixedCodeDocumentFragmentType.Text:
          return (MixedCodeDocumentFragment) new MixedCodeDocumentTextFragment(this);
        default:
          throw new NotSupportedException();
      }
    }

    internal Encoding GetOutEncoding()
    {
      if (this._streamencoding != null)
        return this._streamencoding;
      return Encoding.UTF8;
    }

    private void IncrementPosition()
    {
      ++this._index;
      if (this._c == 10)
      {
        this._lineposition = 1;
        ++this._line;
      }
      else
        ++this._lineposition;
    }

    private void Parse()
    {
      this._state = MixedCodeDocument.ParseState.Text;
      this._index = 0;
      this._currentfragment = this.CreateFragment(MixedCodeDocumentFragmentType.Text);
      while (this._index < this._text.Length)
      {
        this._c = (int) this._text[this._index];
        this.IncrementPosition();
        switch (this._state)
        {
          case MixedCodeDocument.ParseState.Text:
            if (this._index + this.TokenCodeStart.Length < this._text.Length && this._text.Substring(this._index - 1, this.TokenCodeStart.Length) == this.TokenCodeStart)
            {
              this._state = MixedCodeDocument.ParseState.Code;
              this._currentfragment.Length = this._index - 1 - this._currentfragment.Index;
              this._currentfragment = this.CreateFragment(MixedCodeDocumentFragmentType.Code);
              this.SetPosition();
              continue;
            }
            continue;
          case MixedCodeDocument.ParseState.Code:
            if (this._index + this.TokenCodeEnd.Length < this._text.Length && this._text.Substring(this._index - 1, this.TokenCodeEnd.Length) == this.TokenCodeEnd)
            {
              this._state = MixedCodeDocument.ParseState.Text;
              this._currentfragment.Length = this._index + this.TokenCodeEnd.Length - this._currentfragment.Index;
              this._index += this.TokenCodeEnd.Length;
              this._lineposition += this.TokenCodeEnd.Length;
              this._currentfragment = this.CreateFragment(MixedCodeDocumentFragmentType.Text);
              this.SetPosition();
              continue;
            }
            continue;
          default:
            continue;
        }
      }
      this._currentfragment.Length = this._index - this._currentfragment.Index;
    }

    private void SetPosition()
    {
      this._currentfragment.Line = this._line;
      this._currentfragment._lineposition = this._lineposition;
      this._currentfragment.Index = this._index - 1;
      this._currentfragment.Length = 0;
    }

    private enum ParseState
    {
      Text,
      Code,
    }
  }
}
