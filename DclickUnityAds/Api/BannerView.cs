using System;
using DclickUnityAds.Android;

namespace DclickUnityAds.Api
{
    public class BannerView
    {
        private Banner banner;

        public BannerView(string adUnitId, AdPosition position, AdSize size)
        {
            this.banner = new Banner();
            banner.CreateBannerView(adUnitId, position, size);
        }
        
        public void LoadAd()
        {
            banner.LoadAd();
        }
        public void Show()
        {
            banner.Show();
        }

        public void Hide()
        {
            banner.Hide();
        }

        public void Destroy()
        {
            banner.Destroy();
        }
    }
}