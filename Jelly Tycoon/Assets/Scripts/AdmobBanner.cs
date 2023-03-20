using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobBanner : MonoBehaviour
{
    // ���� ���� ID
    private string adUnitId = "ca-app-pub-3940256099942544/6300978111";

    private BannerView bannerView;

    // �ȵ���̵� SDK�� �ʱ�ȭ�ϴ� �޼ҵ�
    void Start()
    {
        MobileAds.Initialize(initStatus =>{   });

        CreateBannerView();
    }

    // ���� �ν��Ͻ��� �����ϴ� �޼ҵ�
    private void CreateBannerView()
    {
        if (bannerView != null)
        {
            bannerView.Destroy();
        }

        AdSize adaptiveSize = AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

        bannerView = new BannerView(adUnitId, adaptiveSize, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        bannerView.LoadAd(request);
    }

    // ���� ǥ���ϴ� �޼ҵ�
    public void LoadAd()
    {
        if (bannerView == null)
        {
            CreateBannerView();
        }

        var adRequest = new AdRequest.Builder()
            .AddKeyword("unity-admob-sample")
            .Build();

        bannerView.LoadAd(adRequest);
    }
}
