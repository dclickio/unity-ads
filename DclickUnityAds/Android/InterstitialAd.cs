using System;
using UnityEngine;
using DclickUnityAds.Api;
using DclickUnityAds.Common;

namespace DclickUnityAds.Android
{
  public class InterstitialAd : AndroidJavaProxy, IInterstitialAd
  {
    public event Action OnAdLoaded;
    public event Action OnAdClosed;
    public event Action OnAdFailed;

    private AndroidJavaObject adManager;
    public InterstitialAd() : base("io.dclick.ads.listeners.InterstitialAdListener")
    {
      this.adManager = AdManager.Instance.androidAdManager;
    }
    public void Load()
    {
      this.adManager.Call(
            "loadInterstitialAd",
            new object[1] { this });
    }
    public void Show()
    {
      this.adManager.Call("showInterstitialAd");
    }
    public void Destroy()
    {
      this.adManager.Call("destroyInterstitialAd");
    }

    public void onAdLoaded()
    {
      if (this.OnAdLoaded != null)
      {
        this.OnAdLoaded();
      }
    }

    public void onAdClosed()
    {
      if (this.OnAdClosed != null)
      {
        this.OnAdClosed();
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