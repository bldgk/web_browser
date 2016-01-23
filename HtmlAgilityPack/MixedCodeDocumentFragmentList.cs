// Decompiled with JetBrains decompiler
// Type: HtmlAgilityPack.MixedCodeDocumentFragmentList
// Assembly: HtmlAgilityPack, Version=1.4.6.0, Culture=neutral, PublicKeyToken=bd319b19eaf3b43a
// MVID: 33288599-2B93-45A3-99F5-D89D6188B861
// Assembly location: C:\Users\kiril_000\Downloads\HtmlAgilityPack.1.4.6\Net45\HtmlAgilityPack.dll

using System;
using System.Collections;
using System.Collections.Generic;

namespace HtmlAgilityPack
{
  /// <summary>
  /// Represents a list of mixed code fragments.
  /// 
  /// </summary>
  public class MixedCodeDocumentFragmentList : IEnumerable
  {
    private IList<MixedCodeDocumentFragment> _items = (IList<MixedCodeDocumentFragment>) new List<MixedCodeDocumentFragment>();
    private MixedCodeDocument _doc;

    /// <summary>
    /// Gets the Document
    /// 
    /// </summary>
    public MixedCodeDocument Doc
    {
      get
      {
        return this._doc;
      }
    }

    /// <summary>
    /// Gets the number of fragments contained in the list.
    /// 
    /// </summary>
    public int Count
    {
      get
      {
        return this._items.Count;
      }
    }

    /// <summary>
    /// Gets a fragment from the list using its index.
    /// 
    /// </summary>
    public MixedCodeDocumentFragment this[int index]
    {
      get
      {
        return this._items[index];
      }
    }

    internal MixedCodeDocumentFragmentList(MixedCodeDocument doc)
    {
      this._doc = doc;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) this.GetEnumerator();
    }

    /// <summary>
    /// Appends a fragment to the list of fragments.
    /// 
    /// </summary>
    /// <param name="newFragment">The fragment to append. May not be null.</param>
    public void Append(MixedCodeDocumentFragment newFragment)
    {
      if (newFragment == null)
        throw new ArgumentNullException("newFragment");
      this._items.Add(newFragment);
    }

    /// <summary>
    /// Gets an enumerator that can iterate through the fragment list.
    /// 
    /// </summary>
    public MixedCodeDocumentFragmentList.MixedCodeDocumentFragmentEnumerator GetEnumerator()
    {
      return new MixedCodeDocumentFragmentList.MixedCodeDocumentFragmentEnumerator(this._items);
    }

    /// <summary>
    /// Prepends a fragment to the list of fragments.
    /// 
    /// </summary>
    /// <param name="newFragment">The fragment to append. May not be null.</param>
    public void Prepend(MixedCodeDocumentFragment newFragment)
    {
      if (newFragment == null)
        throw new ArgumentNullException("newFragment");
      this._items.Insert(0, newFragment);
    }

    /// <summary>
    /// Remove a fragment from the list of fragments. If this fragment was not in the list, an exception will be raised.
    /// 
    /// </summary>
    /// <param name="fragment">The fragment to remove. May not be null.</param>
    public void Remove(MixedCodeDocumentFragment fragment)
    {
      if (fragment == null)
        throw new ArgumentNullException("fragment");
      int fragmentIndex = this.GetFragmentIndex(fragment);
      if (fragmentIndex == -1)
        throw new IndexOutOfRangeException();
      this.RemoveAt(fragmentIndex);
    }

    /// <summary>
    /// Remove all fragments from the list.
    /// 
    /// </summary>
    public void RemoveAll()
    {
      this._items.Clear();
    }

    /// <summary>
    /// Remove a fragment from the list of fragments, using its index in the list.
    /// 
    /// </summary>
    /// <param name="index">The index of the fragment to remove.</param>
    public void RemoveAt(int index)
    {
      this._items.RemoveAt(index);
    }

    internal void Clear()
    {
      this._items.Clear();
    }

    internal int GetFragmentIndex(MixedCodeDocumentFragment fragment)
    {
      if (fragment == null)
        throw new ArgumentNullException("fragment");
      for (int index = 0; index < this._items.Count; ++index)
      {
        if (this._items[index] == fragment)
          return index;
      }
      return -1;
    }

    /// <summary>
    /// Represents a fragment enumerator.
    /// 
    /// </summary>
    public class MixedCodeDocumentFragmentEnumerator : IEnumerator
    {
      private int _index;
      private IList<MixedCodeDocumentFragment> _items;

      /// <summary>
      /// Gets the current element in the collection.
      /// 
      /// </summary>
      public MixedCodeDocumentFragment Current
      {
        get
        {
          return this._items[this._index];
        }
      }

      object IEnumerator.Current
      {
        get
        {
          return (object) this.Current;
        }
      }

      internal MixedCodeDocumentFragmentEnumerator(IList<MixedCodeDocumentFragment> items)
      {
        this._items = items;
        this._index = -1;
      }

      /// <summary>
      /// Advances the enumerator to the next element of the collection.
      /// 
      /// </summary>
      /// 
      /// <returns>
      /// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
      /// </returns>
      public bool MoveNext()
      {
        ++this._index;
        return this._index < this._items.Count;
      }

      /// <summary>
      /// Sets the enumerator to its initial position, which is before the first element in the collection.
      /// 
      /// </summary>
      public void Reset()
      {
        this._index = -1;
      }
    }
  }
}
