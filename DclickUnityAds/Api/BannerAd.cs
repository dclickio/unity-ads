using System;
using UnityEngine;
using DclickUnityAds.Common;

namespace DclickUnityAds.Api
{
  public class BannerAd
  {
    private IBannerAd client;
    public BannerAd(AdPosition position)
    {
      if (Application.platform == RuntimePlatform.Android)
      {
        this.client = new DclickUnityAds.Android.BannerAd(position);
      }
      else if (Application.platform == RuntimePlatform.IPhonePlayer)
      {
        this.client = new DclickUnityAds.iOS.BannerAd(position);
      }
    }

    public Action OnAdLoaded; 
    public Action OnAdFailed;

    public void Load()
    {
      client.OnAdLoaded += OnAdLoaded;
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