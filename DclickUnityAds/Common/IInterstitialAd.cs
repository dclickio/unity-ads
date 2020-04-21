using System;
using DclickUnityAds.Api;

namespace DclickUnityAds.Common
{
  public interface IInterstitialAd
  {
    event Action OnAdLoaded;
    event Action OnAdClosed;
    event Action OnAdFailed;
    void Load();
    void Show();
    void Destroy();
  }
}