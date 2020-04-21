using System;
using UnityEngine;
using DclickUnityAds.Api;
using DclickUnityAds.Common;

namespace DclickUnityAds.iOS
{
  public class InterstitialAd : IInterstitialAd
  {
    public event Action OnAdLoaded;
    public event Action OnAdClosed;
    public event Action OnAdFailed;

    public InterstitialAd()
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