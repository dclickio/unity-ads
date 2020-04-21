using System;
using UnityEngine;
using DclickUnityAds.Common;

namespace DclickUnityAds.Api
{
    public class AdManager
    {
        private static AdManager instance;
        private IAdManager iAdManager = GetAdManager();

        public static AdManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AdManager();
                }
                return instance;
            }
        }

        public static void Initialize()
        {
            Instance.iAdManager.Initialize();
        }

        public static void Initialize(AdConfig adConfig)
        {
            Instance.iAdManager.Initialize(adConfig);
        }

        private static IAdManager GetAdManager() {
            if (Application.platform == RuntimePlatform.Android)
            {
                return new DclickUnityAds.Android.AdManager();
            }
            else if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                return new DclickUnityAds.iOS.AdManager();
            }
            else
            {
                return null;
            }
        }
    }
}