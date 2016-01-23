// Decompiled with JetBrains decompiler
// Type: HtmlAgilityPack.HtmlNodeCollection
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
  public class HtmlNodeCollection : IList<HtmlNode>, ICollection<HtmlNode>, IEnumerable<HtmlNode>, IEnumerable
  {
    private readonly List<HtmlNode> _items = new List<HtmlNode>();
    private readonly HtmlNode _parentnode;

    /// <summary>
    /// Gets a given node from the list.
    /// 
    /// </summary>
    public int this[HtmlNode node]
    {
      get
      {
        int nodeIndex = this.GetNodeIndex(node);
        if (nodeIndex == -1)
          throw new ArgumentOutOfRangeException("node", "Node \"" + node.CloneNode(false).OuterHtml + "\" was not found in the collection");
        return nodeIndex;
      }
    }

    /// <summary>
    /// Get node with tag name
    /// 
    /// </summary>
    /// <param name="nodeName"/>
    /// <returns/>
    public HtmlNode this[string nodeName]
    {
      get
      {
        nodeName = nodeName.ToLower();
        for (int index = 0; index < this._items.Count; ++index)
        {
          if (this._items[index].Name.Equals(nodeName))
            return this._items[index];
        }
        return (HtmlNode) null;
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
        return this._items.Count;
      }
    }

    /// <summary>
    /// Is collection read only
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
    /// Gets the node at the specified index.
    /// 
    /// </summary>
    public HtmlNode this[int index]
    {
      get
      {
        return this._items[index];
      }
      set
      {
        this._items[index] = value;
      }
    }

    /// <summary>
    /// Initialize the HtmlNodeCollection with the base parent node
    /// 
    /// </summary>
    /// <param name="parentnode">The base node of the collection</param>
    public HtmlNodeCollection(HtmlNode parentnode)
    {
      this._parentnode = parentnode;
    }

    /// <summary>
    /// Add node to the collection
    /// 
    /// </summary>
    /// <param name="node"/>
    public void Add(HtmlNode node)
    {
      this._items.Add(node);
    }

    /// <summary>
    /// Clears out the collection of HtmlNodes. Removes each nodes reference to parentnode, nextnode and prevnode
    /// 
    /// </summary>
    public void Clear()
    {
      foreach (HtmlNode htmlNode in this._items)
      {
        htmlNode.ParentNode = (HtmlNode) null;
        htmlNode.NextSibling = (HtmlNode) null;
        htmlNode.PreviousSibling = (HtmlNode) null;
      }
      this._items.Clear();
    }

    /// <summary>
    /// Gets existence of node in collection
    /// 
    /// </summary>
    /// <param name="item"/>
    /// <returns/>
    public bool Contains(HtmlNode item)
    {
      return this._items.Contains(item);
    }

    /// <summary>
    /// Copy collection to array
    /// 
    /// </summary>
    /// <param name="array"/><param name="arrayIndex"/>
    public void CopyTo(HtmlNode[] array, int arrayIndex)
    {
      this._items.CopyTo(array, arrayIndex);
    }

    IEnumerator<HtmlNode> IEnumerable<HtmlNode>.GetEnumerator()
    {
      return (IEnumerator<HtmlNode>) this._items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) this._items.GetEnumerator();
    }

    /// <summary>
    /// Get index of node
    /// 
    /// </summary>
    /// <param name="item"/>
    /// <returns/>
    public int IndexOf(HtmlNode item)
    {
      return this._items.IndexOf(item);
    }

    /// <summary>
    /// Insert node at index
    /// 
    /// </summary>
    /// <param name="index"/><param name="node"/>
    public void Insert(int index, HtmlNode node)
    {
      HtmlNode htmlNode1 = (HtmlNode) null;
      HtmlNode htmlNode2 = (HtmlNode) null;
      if (index > 0)
        htmlNode2 = this._items[index - 1];
      if (index < this._items.Count)
        htmlNode1 = this._items[index];
      this._items.Insert(index, node);
      if (htmlNode2 != null)
      {
        if (node == htmlNode2)
          throw new InvalidProgramException("Unexpected error.");
        htmlNode2._nextnode = node;
      }
      if (htmlNode1 != null)
        htmlNode1._prevnode = node;
      node._prevnode = htmlNode2;
      if (htmlNode1 == node)
        throw new InvalidProgramException("Unexpected error.");
      node._nextnode = htmlNode1;
      node._parentnode = this._parentnode;
    }

    /// <summary>
    /// Remove node
    /// 
    /// </summary>
    /// <param name="item"/>
    /// <returns/>
    public bool Remove(HtmlNode item)
    {
      this.RemoveAt(this._items.IndexOf(item));
      return true;
    }

    /// <summary>
    /// Remove <see cref="T:HtmlAgilityPack.HtmlNode"/> at index
    /// 
    /// </summary>
    /// <param name="index"/>
    public void RemoveAt(int index)
    {
      HtmlNode htmlNode1 = (HtmlNode) null;
      HtmlNode htmlNode2 = (HtmlNode) null;
      HtmlNode htmlNode3 = this._items[index];
      if (index > 0)
        htmlNode2 = this._items[index - 1];
      if (index < this._items.Count - 1)
        htmlNode1 = this._items[index + 1];
      this._items.RemoveAt(index);
      if (htmlNode2 != null)
      {
        if (htmlNode1 == htmlNode2)
          throw new InvalidProgramException("Unexpected error.");
        htmlNode2._nextnode = htmlNode1;
      }
      if (htmlNode1 != null)
        htmlNode1._prevnode = htmlNode2;
      htmlNode3._prevnode = (HtmlNode) null;
      htmlNode3._nextnode = (HtmlNode) null;
      htmlNode3._parentnode = (HtmlNode) null;
    }

    /// <summary>
    /// Get first instance of node in supplied collection
    /// 
    /// </summary>
    /// <param name="items"/><param name="name"/>
    /// <returns/>
    public static HtmlNode FindFirst(HtmlNodeCollection items, string name)
    {
      foreach (HtmlNode htmlNode in (IEnumerable<HtmlNode>) items)
      {
        if (htmlNode.Name.ToLower().Contains(name))
          return htmlNode;
        if (htmlNode.HasChildNodes)
        {
          HtmlNode first = HtmlNodeCollection.FindFirst(htmlNode.ChildNodes, name);
          if (first != null)
            return first;
        }
      }
      return (HtmlNode) null;
    }

    /// <summary>
    /// Add node to the end of the collection
    /// 
    /// </summary>
    /// <param name="node"/>
    public void Append(HtmlNode node)
    {
      HtmlNode htmlNode = (HtmlNode) null;
      if (this._items.Count > 0)
        htmlNode = this._items[this._items.Count - 1];
      this._items.Add(node);
      node._prevnode = htmlNode;
      node._nextnode = (HtmlNode) null;
      node._parentnode = this._parentnode;
      if (htmlNode == null)
        return;
      if (htmlNode == node)
        throw new InvalidProgramException("Unexpected error.");
      htmlNode._nextnode = node;
    }

    /// <summary>
    /// Get first instance of node with name
    /// 
    /// </summary>
    /// <param name="name"/>
    /// <returns/>
    public HtmlNode FindFirst(string name)
    {
      return HtmlNodeCollection.FindFirst(this, name);
    }

    /// <summary>
    /// Get index of node
    /// 
    /// </summary>
    /// <param name="node"/>
    /// <returns/>
    public int GetNodeIndex(HtmlNode node)
    {
      for (int index = 0; index < this._items.Count; ++index)
      {
        if (node == this._items[index])
          return index;
      }
      return -1;
    }

    /// <summary>
    /// Add node to the beginning of the collection
    /// 
    /// </summary>
    /// <param name="node"/>
    public void Prepend(HtmlNode node)
    {
      HtmlNode htmlNode = (HtmlNode) null;
      if (this._items.Count > 0)
        htmlNode = this._items[0];
      this._items.Insert(0, node);
      if (node == htmlNode)
        throw new InvalidProgramException("Unexpected error.");
      node._nextnode = htmlNode;
      node._prevnode = (HtmlNode) null;
      node._parentnode = this._parentnode;
      if (htmlNode == null)
        return;
      htmlNode._prevnode = node;
    }

    /// <summary>
    /// Remove node at index
    /// 
    /// </summary>
    /// <param name="index"/>
    /// <returns/>
    public bool Remove(int index)
    {
      this.RemoveAt(index);
      return true;
    }

    /// <summary>
    /// Replace node at index
    /// 
    /// </summary>
    /// <param name="index"/><param name="node"/>
    public void Replace(int index, HtmlNode node)
    {
      HtmlNode htmlNode1 = (HtmlNode) null;
      HtmlNode htmlNode2 = (HtmlNode) null;
      HtmlNode htmlNode3 = this._items[index];
      if (index > 0)
        htmlNode2 = this._items[index - 1];
      if (index < this._items.Count - 1)
        htmlNode1 = this._items[index + 1];
      this._items[index] = node;
      if (htmlNode2 != null)
      {
        if (node == htmlNode2)
          throw new InvalidProgramException("Unexpected error.");
        htmlNode2._nextnode = node;
      }
      if (htmlNode1 != null)
        htmlNode1._prevnode = node;
      node._prevnode = htmlNode2;
      if (htmlNode1 == node)
        throw new InvalidProgramException("Unexpected error.");
      node._nextnode = htmlNode1;
      node._parentnode = this._parentnode;
      htmlNode3._prevnode = (HtmlNode) null;
      htmlNode3._nextnode = (HtmlNode) null;
      htmlNode3._parentnode = (HtmlNode) null;
    }

    /// <summary>
    /// Get all node descended from this collection
    /// 
    /// </summary>
    /// 
    /// <returns/>
    public IEnumerable<HtmlNode> Descendants()
    {
      foreach (HtmlNode htmlNode1 in this._items)
      {
        foreach (HtmlNode htmlNode2 in htmlNode1.Descendants())
          yield return htmlNode2;
      }
    }

    /// <summary>
    /// Get all node descended from this collection with matching name
    /// 
    /// </summary>
    /// 
    /// <returns/>
    public IEnumerable<HtmlNode> Descendants(string name)
    {
      foreach (HtmlNode htmlNode1 in this._items)
      {
        foreach (HtmlNode htmlNode2 in htmlNode1.Descendants(name))
          yield return htmlNode2;
      }
    }

    /// <summary>
    /// Gets all first generation elements in collection
    /// 
    /// </summary>
    /// 
    /// <returns/>
    public IEnumerable<HtmlNode> Elements()
    {
      foreach (HtmlNode htmlNode1 in this._items)
      {
        foreach (HtmlNode htmlNode2 in (IEnumerable<HtmlNode>) htmlNode1.ChildNodes)
          yield return htmlNode2;
      }
    }

    /// <summary>
    /// Gets all first generation elements matching name
    /// 
    /// </summary>
    /// <param name="name"/>
    /// <returns/>
    public IEnumerable<HtmlNode> Elements(string name)
    {
      foreach (HtmlNode htmlNode1 in this._items)
      {
        foreach (HtmlNode htmlNode2 in htmlNode1.Elements(name))
          yield return htmlNode2;
      }
    }

    /// <summary>
    /// All first generation nodes in collection
    /// 
    /// </summary>
    /// 
    /// <returns/>
    public IEnumerable<HtmlNode> Nodes()
    {
      foreach (HtmlNode htmlNode1 in this._items)
      {
        foreach (HtmlNode htmlNode2 in (IEnumerable<HtmlNode>) htmlNode1.ChildNodes)
          yield return htmlNode2;
      }
    }
  }
}
