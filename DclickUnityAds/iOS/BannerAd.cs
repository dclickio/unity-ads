using System;
using UnityEngine;
using DclickUnityAds.Api;
using DclickUnityAds.Common;

namespace DclickUnityAds.iOS
{
  public class BannerAd : IBannerAd
  {
    public event Action OnAdLoaded;
    public event Action OnAdFailed;

    public BannerAd(AdPosition adPosition)
    {
    }
    public void Load()
    {
    }
    public void Show()
    {
    }
    public void Hide()
    {
    }
    public void Destroy()
    {
    }
  }
}