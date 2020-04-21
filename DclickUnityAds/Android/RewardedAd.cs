using System;
using UnityEngine;
using DclickUnityAds.Api;
using DclickUnityAds.Common;

namespace DclickUnityAds.Android
{
  public class RewardedAd : AndroidJavaProxy, IRewardedAd
  {
    public event Action OnAdLoaded;
    public event Action OnAdClosed;
    public event Action OnAdFailed;
    public event Action OnRewardEarned;

    private AndroidJavaObject adManager;
    public RewardedAd() : base("io.dclick.ads.listeners.RewardedAdListener")
    {
      this.adManager = AdManager.Instance.androidAdManager;
    }
    public void Load()
    {
      this.adManager.Call(
            "loadRewardedAd",
            new object[1] { this });
    }
    public void Show()
    {
      this.adManager.Call("showRewardedAd");
    }
    public void Destroy()
    {
      this.adManager.Call("destroyRewardedAd");
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

    public void onRewardEarned()
    {
      if (this.OnRewardEarned != null)
      {
        this.OnRewardEarned();
      }
    }
  }
}