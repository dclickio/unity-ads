using System;
using System.Collections;
using UnityEngine;
using DclickUnityAds.Api;
using DclickUnityAds.Common;

namespace DclickUnityAds.Android
{
    public class AdManager : AndroidJavaProxy, IAdManager
    {
        private static AdManager instance;
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
        public AndroidJavaObject androidAdManager;

        public AdManager() : base("io.dclick.ads.unity.UnityAdManager")
        {

        }
        void IAdManager.Initialize()
        {
          AdManager.Initialize();
        }

        void IAdManager.Initialize(AdConfig adConfig)
        {
          AdManager.Initialize(adConfig);
        }

        public static void Initialize()
        {
          AndroidJavaClass playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
          AndroidJavaObject activity =
            playerClass.GetStatic<AndroidJavaObject>("currentActivity");
          
          Instance.androidAdManager = new AndroidJavaObject("io.dclick.ads.unity.UnityAdManager");
          Instance.androidAdManager.Call("initialize", activity);
        }

        public static void Initialize(AdConfig adConfig)
        {
            AndroidJavaClass playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activity =
                    playerClass.GetStatic<AndroidJavaObject>("currentActivity");

            Instance.androidAdManager =
                    new AndroidJavaObject("io.dclick.ads.unity.UnityAdManager");

            AndroidJavaObject androidAdConfig =
                    new AndroidJavaObject("io.dclick.ads.AdConfig");
            
            AndroidJavaClass androidAdNetwork =
                    new AndroidJavaClass("io.dclick.ads.AdNetwork");

            AndroidJavaClass androidAdType =
                    new AndroidJavaClass("io.dclick.ads.AdType");

            foreach (DictionaryEntry each in adConfig.ApiKeys) {
              string adNetwork = each.Key.ToString();
              string apiKey = (string) each.Value;
              androidAdConfig.Call(
                "setApiKey",
                androidAdNetwork.GetStatic<AndroidJavaObject>(adNetwork),
                apiKey);
            };

            foreach (DictionaryEntry networks in adConfig.UnitIds) {
              string adNetwork = networks.Key.ToString();
              Hashtable types = (Hashtable) networks.Value;
              foreach (DictionaryEntry each in types) {
                string adType = each.Key.ToString().ToUpper();
                string unitId = (string) each.Value;

                androidAdConfig.Call(
                  "setUnitId",
                  androidAdNetwork.GetStatic<AndroidJavaObject>(adNetwork),
                  androidAdType.GetStatic<AndroidJavaObject>(adType),
                  unitId
                );
              }
            }

            Instance.androidAdManager.Call("initialize", activity, androidAdConfig);
        }
    }
}