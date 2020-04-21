using System;
using DclickUnityAds.Api;

namespace DclickUnityAds.Common
{
  public interface IRewardedAd
  {
    event Action OnAdLoaded;
    event Action OnAdClosed;
    event Action OnAdFailed;
    event Action OnRewardEarned;
    void Load();
    void Show();
    void Destroy();
  }
}