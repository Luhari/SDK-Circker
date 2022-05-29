using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronSourceScript : MonoBehaviour
{
    [SerializeField]
    private string YOUR_APP_KEY;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Ironsource");
        IronSourceEvents.onSdkInitializationCompletedEvent += SdkInitializationCompletedEvent;
        InitIronSourceAd();

        IronSource.Agent.setMetaData("UnityAds_coppa", "false");

        IronSource.Agent.setAdaptersDebug(true);
        Debug.Log("set Adapter debug TRUE!");

        IronSource.Agent.validateIntegration();
        Debug.Log("End validated integration!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnApplicationPause(bool pause)
    {
        IronSource.Agent.onApplicationPause(pause);
    }

    private void InitIronSourceAd()
    {
        //For Rewarded Video
        IronSource.Agent.init(YOUR_APP_KEY, IronSourceAdUnits.REWARDED_VIDEO);
        //For Interstitial
        IronSource.Agent.init(YOUR_APP_KEY, IronSourceAdUnits.INTERSTITIAL);
        //For Offerwall
        IronSource.Agent.init(YOUR_APP_KEY, IronSourceAdUnits.OFFERWALL);
        //For Banners
        IronSource.Agent.init(YOUR_APP_KEY, IronSourceAdUnits.BANNER);

        // IronSource.Agent.init(YOUR_APP_KEY);

        Debug.Log(IronSource.Agent.ToString());

        Debug.Log("Iron source Initialized!");

    }
    private void SdkInitializationCompletedEvent() 
    {
        InitIronSourceAd();
    }

    
}
