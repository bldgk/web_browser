// Decompiled with JetBrains decompiler
// Type: HtmlAgilityPack.HtmlAttributeCollection
// Assembly: HtmlAgilityPack, Version=1.4.6.0, Culture=neutral, PublicKeyToken=bd319b19eaf3b43a
// MVID: 33288599-2B93-45A3-99F5-D89D6188B861
// Assembly location: C:\Users\kiril_000\Downloads\HtmlAgilityPack.1.4.6\Net45\HtmlAgilityPack.dll

using System;
using System.Collections;
using System.Collections.Generic;

namespace HtmlAgilityPack
{
  /// <summary>
  /// Represents a combined list and collection of HTML nodes.
  /// 
  /// </summary>
  public class HtmlAttributeCollection : IList<HtmlAttribute>, ICollection<HtmlAttribute>, IEnumerable<HtmlAttribute>, IEnumerable
  {
    internal Dictionary<string, HtmlAttribute> Hashitems = new Dictionary<string, HtmlAttribute>();
    private List<HtmlAttribute> items = new List<HtmlAttribute>();
    private HtmlNode _ownernode;

    /// <summary>
    /// Gets a given attribute from the list using its name.
    /// 
    /// </summary>
    public HtmlAttribute this[string name]
    {
      get
      {
        if (name == null)
          throw new ArgumentNullException("name");
        HtmlAttribute htmlAttribute;
        if (!this.Hashitems.TryGetValue(name.ToLower(), out htmlAttribute))
          return (HtmlAttribute) null;
        return htmlAttribute;
      }
      set
      {
        this.Append(value);
      }
    }

    /// <summary>
    /// Gets the number of elements actually contained in the list.
    /// 
    /// </summary>
    public int Count
    {
      get
      {
        return this.items.Count;
      }
    }

    /// <summary>
    /// Gets readonly status of colelction
    /// 
    /// </summary>
    public bool IsReadOnly
    {
      get
      {
        return false;
      }
    }

    /// <summary>
    /// Gets the attribute at the specified index.
    /// 
    /// </summary>
    public HtmlAttribute this[int index]
    {
      get
      {
        return this.items[index];
      }
      set
      {
        this.items[index] = value;
      }
    }

    internal HtmlAttributeCollection(HtmlNode ownernode)
    {
      this._ownernode = ownernode;
    }

    /// <summary>
    /// Adds supplied item to collection
    /// 
    /// </summary>
    /// <param name="item"/>
    public void Add(HtmlAttribute item)
    {
      this.Append(item);
    }

    void ICollection<HtmlAttribute>.Clear()
    {
      this.items.Clear();
    }

    /// <summary>
    /// Retreives existence of supplied item
    /// 
    /// </summary>
    /// <param name="item"/>
    /// <returns/>
    public bool Contains(HtmlAttribute item)
    {
      return this.items.Contains(item);
    }

    /// <summary>
    /// Copies collection to array
    /// 
    /// </summary>
    /// <param name="array"/><param name="arrayIndex"/>
    public void CopyTo(HtmlAttribute[] array, int arrayIndex)
    {
      this.items.CopyTo(array, arrayIndex);
    }

    IEnumerator<HtmlAttribute> IEnumerable<HtmlAttribute>.GetEnumerator()
    {
      return (IEnumerator<HtmlAttribute>) this.items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) this.items.GetEnumerator();
    }

    /// <summary>
    /// Retrieves the index for the supplied item, -1 if not found
    /// 
    /// </summary>
    /// <param name="item"/>
    /// <returns/>
    public int IndexOf(HtmlAttribute item)
    {
      return this.items.IndexOf(item);
    }

    /// <summary>
    /// Inserts given item into collection at supplied index
    /// 
    /// </summary>
    /// <param name="index"/><param name="item"/>
    public void Insert(int index, HtmlAttribute item)
    {
      if (item == null)
        throw new ArgumentNullException("item");
      this.Hashitems[item.Name] = item;
      item._ownernode = this._ownernode;
      this.items.Insert(index, item);
      this._ownernode._innerchanged = true;
      this._ownernode._outerchanged = true;
    }

    bool ICollection<HtmlAttribute>.Remove(HtmlAttribute item)
    {
      return this.items.Remove(item);
    }

    /// <summary>
    /// Removes the attribute at the specified index.
    /// 
    /// </summary>
    /// <param name="index">The index of the attribute to remove.</param>
    public void RemoveAt(int index)
    {
      this.Hashitems.Remove(this.items[index].Name);
      this.items.RemoveAt(index);
      this._ownernode._innerchanged = true;
      this._ownernode._outerchanged = true;
    }

    /// <summary>
    /// Adds a new attribute to the collection with the given values
    /// 
    /// </summary>
    /// <param name="name"/><param name="value"/>
    public void Add(string name, string value)
    {
      this.Append(name, value);
    }

    /// <summary>
    /// Inserts the specified attribute as the last attribute in the collection.
    /// 
    /// </summary>
    /// <param name="newAttribute">The attribute to insert. May not be null.</param>
    /// <returns>
    /// The appended attribute.
    /// </returns>
    public HtmlAttribute Append(HtmlAttribute newAttribute)
    {
      if (newAttribute == null)
        throw new ArgumentNullException("newAttribute");
      this.Hashitems[newAttribute.Name] = newAttribute;
      newAttribute._ownernode = this._ownernode;
      this.items.Add(newAttribute);
      this._ownernode._innerchanged = true;
      this._ownernode._outerchanged = true;
      return newAttribute;
    }

    /// <summary>
    /// Creates and inserts a new attribute as the last attribute in the collection.
    /// 
    /// </summary>
    /// <param name="name">The name of the attribute to insert.</param>
    /// <returns>
    /// The appended attribute.
    /// </returns>
    public HtmlAttribute Append(string name)
    {
      return this.Append(this._ownernode._ownerdocument.CreateAttribute(name));
    }

    /// <summary>
    /// Creates and inserts a new attribute as the last attribute in the collection.
    /// 
    /// </summary>
    /// <param name="name">The name of the attribute to insert.</param><param name="value">The value of the attribute to insert.</param>
    /// <returns>
    /// The appended attribute.
    /// </returns>
    public HtmlAttribute Append(string name, string value)
    {
      return this.Append(this._ownernode._ownerdocument.CreateAttribute(name, value));
    }

    /// <summary>
    /// Checks for existance of attribute with given name
    /// 
    /// </summary>
    /// <param name="name"/>
    /// <returns/>
    public bool Contains(string name)
    {
      for (int index = 0; index < this.items.Count; ++index)
      {
        if (this.items[index].Name.Equals(name.ToLower()))
          return true;
      }
      return false;
    }

    /// <summary>
    /// Inserts the specified attribute as the first node in the collection.
    /// 
    /// </summary>
    /// <param name="newAttribute">The attribute to insert. May not be null.</param>
    /// <returns>
    /// The prepended attribute.
    /// </returns>
    public HtmlAttribute Prepend(HtmlAttribute newAttribute)
    {
      this.Insert(0, newAttribute);
      return newAttribute;
    }

    /// <summary>
    /// Removes a given attribute from the list.
    /// 
    /// </summary>
    /// <param name="attribute">The attribute to remove. May not be null.</param>
    public void Remove(HtmlAttribute attribute)
    {
      if (attribute == null)
        throw new ArgumentNullException("attribute");
      int attributeIndex = this.GetAttributeIndex(attribute);
      if (attributeIndex == -1)
        throw new IndexOutOfRangeException();
      this.RemoveAt(attributeIndex);
    }

    /// <summary>
    /// Removes an attribute from the list, using its name. If there are more than one attributes with this name, they will all be removed.
    /// 
    /// </summary>
    /// <param name="name">The attribute's name. May not be null.</param>
    public void Remove(string name)
    {
      if (name == null)
        throw new ArgumentNullException("name");
      string str = name.ToLower();
      for (int index = 0; index < this.items.Count; ++index)
      {
        if (this.items[index].Name == str)
          this.RemoveAt(index);
      }
    }

    /// <summary>
    /// Remove all attributes in the list.
    /// 
    /// </summary>
    public void RemoveAll()
    {
      this.Hashitems.Clear();
      this.items.Clear();
      this._ownernode._innerchanged = true;
      this._ownernode._outerchanged = true;
    }

    /// <summary>
    /// Returns all attributes with specified name. Handles case insentivity
    /// 
    /// </summary>
    /// <param name="attributeName">Name of the attribute</param>
    /// <returns/>
    public IEnumerable<HtmlAttribute> AttributesWithName(string attributeName)
    {
      attributeName = attributeName.ToLower();
      for (int i = 0; i < this.items.Count; ++i)
      {
        if (this.items[i].Name.Equals(attributeName))
          yield return this.items[i];
      }
    }

    /// <summary>
    /// Removes all attributes from the collection
    /// 
    /// </summary>
    public void Remove()
    {
      foreach (HtmlAttribute htmlAttribute in this.items)
        htmlAttribute.Remove();
    }

    /// <summary>
    /// Clears the attribute collection
    /// 
    /// </summary>
    internal void Clear()
    {
      this.Hashitems.Clear();
      this.items.Clear();
    }

    internal int GetAttributeIndex(HtmlAttribute attribute)
    {
      if (attribute == null)
        throw new ArgumentNullException("attribute");
      for (int index = 0; index < this.items.Count; ++index)
      {
        if (this.items[index] == attribute)
          return index;
      }
      return -1;
    }

    internal int GetAttributeIndex(string name)
    {
      if (name == null)
        throw new ArgumentNullException("name");
      string str = name.ToLower();
      for (int index = 0; index < this.items.Count; ++index)
      {
        if (this.items[index].Name == str)
          return index;
      }
      return -1;
    }
  }
}
