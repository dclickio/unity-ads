using System;
using UnityEngine;
using DclickUnityAds.Api;
using DclickUnityAds.Common;

namespace DclickUnityAds.iOS
{
  public class RewardedAd : IRewardedAd
  {
    public event Action OnAdLoaded;
    public event Action OnAdClosed;
    public event Action OnAdFailed;
    public event Action OnRewardEarned;

    public RewardedAd()
    {
    }
    public void Load()
    {
    }
    public void Show()
    {
    }
    public void Destroy()
    {
    }
  }
}