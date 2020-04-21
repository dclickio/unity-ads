using System;
using UnityEngine;
using DclickUnityAds.Api;
using DclickUnityAds.Common;

namespace DclickUnityAds.iOS
{
  public class AdManager : IAdManager
  {
    void IAdManager.Initialize()
    {
      AdManager.Initialize();
    }

    void IAdManager.Initialize(AdConfig adConfig)
    {
      AdManager.Initialize(adConfig);
    }

    public static void Initialize()
    {
      
    }

    public static void Initialize(AdConfig adConfig)
    {
    }
  }
}