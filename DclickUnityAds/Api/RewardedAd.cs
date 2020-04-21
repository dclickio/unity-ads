using System;
using UnityEngine;
using DclickUnityAds.Common;

namespace DclickUnityAds.Api
{
  public class RewardedAd
  {
    private IRewardedAd client;
    public RewardedAd()
    {
      if (Application.platform == RuntimePlatform.Android)
      {
        this.client = new DclickUnityAds.Android.RewardedAd();
      }
      else if (Application.platform == RuntimePlatform.IPhonePlayer)
      {
        this.client = new DclickUnityAds.iOS.RewardedAd();
      }
    }

    public Action OnAdLoaded;
    public Action OnAdClosed;
    public Action OnAdFailed;
    public Action OnRewardEarned;

    public void Load()
    {
      client.OnAdLoaded += OnAdLoaded;
      client.OnAdClosed += OnAdClosed;
      client.OnAdFailed += OnAdFailed;
      client.OnRewardEarned += OnRewardEarned;
      client.Load();
    }

    public void Show()
    {
      client.Show();
    }

    public void Destroy()
    {
      client.Destroy();
    }
  }
}