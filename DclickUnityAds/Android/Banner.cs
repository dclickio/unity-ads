using System;
using UnityEngine;
using DclickUnityAds.Api;

namespace DclickUnityAds.Android
{
    public class Banner : AndroidJavaProxy
    {
        private AndroidJavaObject bannerView;

        public Banner() : base("io.dclick.ad.unity.UnityAdListener")
        {
            AndroidJavaClass playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activity =
                    playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            this.bannerView = new AndroidJavaObject("io.dclick.ad.unity.Banner", activity, this);
        }

        public void CreateBannerView(string adUnitId, AdPosition position, AdSize size)
        {
            this.bannerView.Call(
                "create",
                new object[4] { adUnitId, (int)position, size.Width, size.Height });
        }

        public void LoadAd()
        {
            this.bannerView.Call("loadAd");
        }

        public void Show()
        {
            this.bannerView.Call("show");
        }

        public void Hide()
        {
            this.bannerView.Call("hide");
        }

        public void Destroy()
        {
            this.bannerView.Call("destroy");
        }
    }
}