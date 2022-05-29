using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronSourceBannerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadBanner()
    {
        IronSource.Agent.loadBanner(IronSourceBannerSize.BANNER, IronSourceBannerPosition.BOTTOM);
    }

    public void hideBanner()
    {
        IronSource.Agent.hideBanner();
    }

    void OnEnable()
    {
        IronSourceEvents.onBannerAdLoadedEvent += BannerAdLoadedEvent;
        IronSourceEvents.onBannerAdLoadFailedEvent += BannerAdLoadFailedEvent;
        IronSourceEvents.onBannerAdClickedEvent += BannerAdClickedEvent;
        IronSourceEvents.onBannerAdScreenPresentedEvent += BannerAdScreenPresentedEvent;
        IronSourceEvents.onBannerAdScreenDismissedEvent += BannerAdScreenDismissedEvent;
        IronSourceEvents.onBannerAdLeftApplicationEvent += BannerAdLeftApplicationEvent;
    }

    //Invoked once the banner has loaded
    void BannerAdLoadedEvent()
    {
        IronSource.Agent.displayBanner();
    }
    //Invoked when the banner loading process has failed.
    //@param description - string - contains information about the failure.
    void BannerAdLoadFailedEvent(IronSourceError error)
    {
        Debug.Log(string.Format("Banner load failed: {0}", error));
    }
    // Invoked when end user clicks on the banner ad
    void BannerAdClickedEvent()
    {
    }
    //Notifies the presentation of a full screen content following user click
    void BannerAdScreenPresentedEvent()
    {

    }
    //Notifies the presented screen has been dismissed
    void BannerAdScreenDismissedEvent()
    {
    }
    //Invoked when the user leaves the app
    void BannerAdLeftApplicationEvent()
    {
        IronSource.Agent.destroyBanner();
    }
}
