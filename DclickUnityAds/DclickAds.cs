using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DclickUnityAds.Android;
using DclickUnityAds.Api;

public class DclickAds : MonoBehaviour
{
  private BannerView bannerView;
  void Start()
  {
    string adUnitId = "io.dclick/test_unit";
    bannerView = new BannerView(adUnitId, AdPosition.Bottom, AdSize.Banner);
    bannerView.LoadAd();
  }
}
