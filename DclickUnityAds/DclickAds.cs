using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DclickUnityAds.Api;

public class DclickAds : MonoBehaviour
{
  private AdManager adManager;
  private BannerAd bannerAd;
  private InterstitialAd interstitialAd;
  private RewardedAd rewardedAd;
  private bool isBannerAdVisible = false;
  void Start()
  {
    // For Test
    // AdManager.Initialize();

    // For Production
    AdConfig adConfig = new AdConfig();
    adConfig.SetApiKey(AdNetwork.Dclick, "test");
    adConfig.SetApiKey(AdNetwork.Google, "ca-app-pub-3940256099942544~3347511713");
    adConfig.SetUnitId(AdNetwork.Dclick, AdType.Banner, "test/test");
    adConfig.SetUnitId(AdNetwork.Google, AdType.Banner, "ca-app-pub-3940256099942544/6300978111");

    adConfig.SetUnitId(AdNetwork.Dclick, AdType.Interstitial, "test/test");
    adConfig.SetUnitId(AdNetwork.Google, AdType.Interstitial, "ca-app-pub-3940256099942544/1033173712");

    adConfig.SetUnitId(AdNetwork.Dclick, AdType.Rewarded, "test/test");
    adConfig.SetUnitId(AdNetwork.Google, AdType.Rewarded, "ca-app-pub-3940256099942544/5224354917");
    
    AdManager.Initialize(adConfig);

    // Load Ads
    this.LoadBannerAd();
    this.LoadInterstitialAd();
    this.LoadRewardedAd();
  }

  void LoadBannerAd()
  {
    this.bannerAd = new BannerAd(AdPosition.Bottom);
    this.bannerAd.OnAdLoaded += () => { };
    this.bannerAd.OnAdFailed += () => { };
    this.bannerAd.Load();
    this.bannerAd.Show();

    this.isBannerAdVisible = true;
  }

  void LoadInterstitialAd()
  {
    this.interstitialAd = new InterstitialAd();
    this.interstitialAd.OnAdLoaded += () => { };
    this.interstitialAd.OnAdClosed += () => { };
    this.interstitialAd.OnAdFailed += () => { };
    this.interstitialAd.Load();
  }

  void LoadRewardedAd()
  {
    this.rewardedAd = new RewardedAd();
    this.rewardedAd.OnAdLoaded += () => { };
    this.rewardedAd.OnAdFailed += () => { };
    this.rewardedAd.OnAdClosed += () => { };
    this.rewardedAd.OnRewardEarned += () => { };
    this.rewardedAd.Load();
  }
  
  public void OnToggleBannerAd()
  {
    if (this.isBannerAdVisible) {
      this.bannerAd.Hide();
      this.isBannerAdVisible = false;
    } else {
      this.bannerAd.Show();
      this.isBannerAdVisible = true;
    }
  }

  public void OnShowInterstitialAd()
  {
    this.interstitialAd.Show();
  }

  public void OnShowRewardedAd()
  {
    this.rewardedAd.Show();
  }
}
