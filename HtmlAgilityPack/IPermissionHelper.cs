// Decompiled with JetBrains decompiler
// Type: HtmlAgilityPack.IPermissionHelper
// Assembly: HtmlAgilityPack, Version=1.4.6.0, Culture=neutral, PublicKeyToken=bd319b19eaf3b43a
// MVID: 33288599-2B93-45A3-99F5-D89D6188B861
// Assembly location: C:\Users\kiril_000\Downloads\HtmlAgilityPack.1.4.6\Net45\HtmlAgilityPack.dll

namespace HtmlAgilityPack
{
  /// <summary>
  /// An interface for getting permissions of the running application
  /// 
  /// </summary>
  public interface IPermissionHelper
  {
    /// <summary>
    /// Checks to see if Registry access is available to the caller
    /// 
    /// </summary>
    /// 
    /// <returns/>
    bool GetIsRegistryAvailable();

    /// <summary>
    /// Checks to see if DNS information is available to the caller
    /// 
    /// </summary>
    /// 
    /// <returns/>
    bool GetIsDnsAvailable();
  }
}
