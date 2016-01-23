// Decompiled with JetBrains decompiler
// Type: HtmlAgilityPack.IOLibrary
// Assembly: HtmlAgilityPack, Version=1.4.6.0, Culture=neutral, PublicKeyToken=bd319b19eaf3b43a
// MVID: 33288599-2B93-45A3-99F5-D89D6188B861
// Assembly location: C:\Users\kiril_000\Downloads\HtmlAgilityPack.1.4.6\Net45\HtmlAgilityPack.dll

using System.IO;
using System.Runtime.InteropServices;

namespace HtmlAgilityPack
{
  [StructLayout(LayoutKind.Sequential, Size = 1)]
  internal struct IOLibrary
  {
    internal static void CopyAlways(string source, string target)
    {
      if (!File.Exists(source))
        return;
      Directory.CreateDirectory(Path.GetDirectoryName(target));
      IOLibrary.MakeWritable(target);
      File.Copy(source, target, true);
    }

    internal static void MakeWritable(string path)
    {
      if (!File.Exists(path))
        return;
      File.SetAttributes(path, File.GetAttributes(path) & ~FileAttributes.ReadOnly);
    }
  }
}
