using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    string gameId;

    // Change Mode false when will published
    private bool testMode = false;    
    private string gameId_IOS = "3645484";
    private string gameId_Andriod = "3645485";

    private string placementId_banner = "banner";
    private string placementId_video = "video";
    private string placementId_rewardedVideo = "rewardedVideo";
    string placementId;

    static AdsManager instance;
    public static AdsManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType(typeof(AdsManager)) as AdsManager;
            }
            return instance;
        }
    }
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            gameId = gameId_Andriod;
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            gameId = gameId_IOS;
        }        
        Advertisement.Initialize(gameId, testMode);
        //Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        
    }

    public void ShowBannerAd()
    {
        StartCoroutine(ShowAd(placementId_banner));
    }
    public void ShowVideoAd()
    {
        StartCoroutine(ShowAd(placementId_video));
    }

    public void ShowRewardedAd()
    {
        StartCoroutine(ShowAd(placementId_rewardedVideo));
    }

    IEnumerator ShowAd(string placementId)
    {
        while (!Advertisement.IsReady(placementId))
        {
            yield return new WaitForSeconds(.5f);
        }

        if(placementId =="banner")
        {
            //Advertisement.Banner.Show(placementId_banner);
        }
        else if(placementId == "video" || placementId == "rewardedVideo")
        {
            Advertisement.Show(placementId);
        }
    }
}
