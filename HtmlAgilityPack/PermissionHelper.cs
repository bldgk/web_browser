// Decompiled with JetBrains decompiler
// Type: HtmlAgilityPack.PermissionHelper
// Assembly: HtmlAgilityPack, Version=1.4.6.0, Culture=neutral, PublicKeyToken=bd319b19eaf3b43a
// MVID: 33288599-2B93-45A3-99F5-D89D6188B861
// Assembly location: C:\Users\kiril_000\Downloads\HtmlAgilityPack.1.4.6\Net45\HtmlAgilityPack.dll

using System;
using System.Net;
using System.Security;
using System.Security.Permissions;

namespace HtmlAgilityPack
{
  /// <summary>
  /// Wraps getting AppDomain permissions
  /// 
  /// </summary>
  public class PermissionHelper : IPermissionHelper
  {
    /// <summary>
    /// Checks to see if Registry access is available to the caller
    /// 
    /// </summary>
    /// 
    /// <returns/>
    public bool GetIsRegistryAvailable()
    {
      PermissionSet permissionSet = new PermissionSet(PermissionState.None);
      RegistryPermission registryPermission = new RegistryPermission(PermissionState.Unrestricted);
      permissionSet.AddPermission((IPermission) registryPermission);
      return permissionSet.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet);
    }

    /// <summary>
    /// Checks to see if DNS information is available to the caller
    /// 
    /// </summary>
    /// 
    /// <returns/>
    public bool GetIsDnsAvailable()
    {
      PermissionSet permissionSet = new PermissionSet(PermissionState.None);
      DnsPermission dnsPermission = new DnsPermission(PermissionState.Unrestricted);
      permissionSet.AddPermission((IPermission) dnsPermission);
      return permissionSet.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet);
    }
  }
}
