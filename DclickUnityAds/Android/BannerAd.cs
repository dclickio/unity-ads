using System;
using UnityEngine;
using DclickUnityAds.Api;
using DclickUnityAds.Common;

namespace DclickUnityAds.Android
{
  public class BannerAd : AndroidJavaProxy, IBannerAd
  {
    public event Action OnAdLoaded;
    public event Action OnAdFailed;

    private AndroidJavaObject adManager;
    private AdPosition adPosition;
    public BannerAd(AdPosition adPosition) : base("io.dclick.ads.listeners.BannerAdListener")
    {
      this.adManager = AdManager.Instance.androidAdManager;
      this.adPosition = adPosition;
    }
    public void Load()
    {
      this.adManager.Call(
            "loadBannerAd",
            new object[2] { (int) this.adPosition, this });
    }
    public void Show()
    {
      this.adManager.Call("showBannerAd");
    }
    public void Hide()
    {
      this.adManager.Call("hideBannerAd");
    }
    public void Destroy()
    {
      this.adManager.Call("destroyBannerAd");
    }

    public void onAdLoaded()
    {
      if (this.OnAdLoaded != null)
      {
        this.OnAdLoaded();
      }
    }

    public void onAdFailed()
    {
      if (this.OnAdFailed != null)
      {
        this.OnAdFailed();
      }
    }
  }
}