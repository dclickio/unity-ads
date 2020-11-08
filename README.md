# DCLICK Unity-ads
[ ![Download](https://api.bintray.com/packages/dclickio/maven/ads/images/download.svg) ](https://bintray.com/dclickio/maven/ads/_latestVersion)


### DCLICK 적용 가이드
DCLICK SDK 를 사용하여 DCLICK 광고 및 기타 다른 광고 플랫폼 ( 애드몹 등등 ) 과 미디에이션 기능을 사용 하는 방법에 대한 가이드 입니다.

### 사전준비
- [https://www.dclick.io](https://www.dclick.io) 에 접속하여 가입 합니다.
- 앱 -> 앱 등록 을 클릭하여 만드신 앱을 등록 합니다.

### 프로젝트 연동
#### 1. Unity 플러그인 가져오기
- [Plugin Download](https://github.com/dclickio/unity-ads/releases/latest/download/DclickUnityAds.unitypackage) 를 클릭하여 Unity 패키지를 다운 받습니다. 이 패키지에는 DCLICK 광고 게재를 위한 인터페이스를 포함하는 C#스크립트가 포함 되어 있습니다.

#### 2. Unity 플러그인 적용하기
- Unity 편집기에서 프로젝트를 열고 Assets -> Import Package -> Custom Package 를 차례대로 선택 합니다.
- 파일 선택창이 나오면 다운로드한 DclickUnityAds.unitypackage 파일을 선택한 후 모든 파일을 선택하고 Import 를 클릭하여 모든 파일을 가져옵니다.
![image](https://www.dclick.io/_nuxt/img/37adf15.png)

#### 3. 광고 적용하기
- 이제 광고를 적용할 모든 준비가 되었습니다. Hierarchy 영역에 새로운 오브젝트를 만들고 DclickUnityAds 폴더 안에 있는 DclickAds.cs C# 스크립트 파일을 적용해 주세요.
![image2](https://www.dclick.io/_nuxt/img/75acc10.png)

#### 4. 코드 수정하기
- DclickAds.cs 스크립트 안에는 띠배너, 전면배너, 보상형 동영상 광고를 연동하는 코드가 포함 되어 있습니다.
- 해당 코드를 참고하셔서 원하는 광고를 연동해 주세요.
```c#
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
    adConfig.SetUnitId(AdNetwork.Google, AdType.Rewarded, "ca-app-pub-3940256099942544/2247696110");
    
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
```

License
-------
[Apache 2.0 License](http://www.apache.org/licenses/LICENSE-2.0.html)
