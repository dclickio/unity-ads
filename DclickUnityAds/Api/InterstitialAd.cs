using System;
using UnityEngine;
using DclickUnityAds.Common;

namespace DclickUnityAds.Api
{
  public class InterstitialAd
  {
    private IInterstitialAd client;
    public InterstitialAd()
    {
      if (Application.platform == RuntimePlatform.Android)
      {
        this.client = new DclickUnityAds.Android.InterstitialAd();
      }
      else if (Application.platform == RuntimePlatform.IPhonePlayer)
      {
        this.client = new DclickUnityAds.iOS.InterstitialAd();
      }
    }

    public Action OnAdLoaded;
    public Action OnAdClosed;
    public Action OnAdFailed;

    public void Load()
    {
      client.OnAdLoaded += OnAdLoaded;
      client.OnAdClosed += OnAdClosed;
      client.OnAdFailed += OnAdFailed;
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