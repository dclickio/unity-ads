using System;
using DclickUnityAds.Api;

namespace DclickUnityAds.Common
{
    public interface IAdManager
    {
        void Initialize();
        void Initialize(AdConfig adConfig);

    }
}