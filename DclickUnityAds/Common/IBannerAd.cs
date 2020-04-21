using System;
using DclickUnityAds.Api;

namespace DclickUnityAds.Common
{
  public interface IBannerAd
  {
    event Action OnAdLoaded;
    event Action OnAdFailed;
    void Load();
    void Show();
    void Destroy();
  }
}