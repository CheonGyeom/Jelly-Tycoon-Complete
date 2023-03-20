using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdmobReward : MonoBehaviour
{
    // ���� ���� ID
    private string adUnitId;

    private RewardedAd rewardedAd;

    public GameManager gm;

    // ������ ���� â
    public GameObject rewardPanel; 

    void Start()
    {
        adUnitId = "ca-app-pub-3940256099942544/5224354917";

        rewardedAd = new RewardedAd(adUnitId);

        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();

        rewardedAd.LoadAd(request);
    }

    //����
    public void Show() 
    {
        StartCoroutine(ShowRewardAd());
    }

    //���� �����ֱ�
    IEnumerator ShowRewardAd()
    {
        while (!rewardedAd.IsLoaded())
        {
            yield return null;
        }
        rewardedAd.Show();
    }

    //���� �ٽ� �ε��ϱ�
    public void ReloadAd()
    {
        adUnitId = "ca-app-pub-3940256099942544/5224354917";


        rewardedAd = new RewardedAd(adUnitId);

        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request);
    }

    //���� ������ ����
    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        ReloadAd();
    }

    //���� ������ ������ �޴� ����
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        SoundManager.instance.PlaySound("BuyDeco");
        rewardPanel.SetActive(true);
    }

    // ���� �ޱ� ��ư (�Ǽ���)
    public void GetReward()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        rewardPanel.SetActive(false);
        gm.jelatin += 50f; // 50 ����ƾ ����
    }


}
