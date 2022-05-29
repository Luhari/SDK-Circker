using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class CircleClickScript : MonoBehaviour
{

    private Vector3 originalScale;
    private float duration = 0.1f;
    private int numberClicks = 0;
    private IronSourceBannerScript ISBannerScript;
    private IronSourceInterstitialScript ISInterstitialScript;

    [SerializeField]
    private PlayFabLeaderBoard PBLeaderboard;

    private TMPro.TMP_Text numberClicksText;
    // Start is called before the first frame update
    void Start()
    {
        originalScale = gameObject.transform.localScale;

        numberClicksText = gameObject.GetComponentInChildren<TMPro.TMP_Text>();

        ISBannerScript = gameObject.GetComponentInChildren<IronSourceBannerScript>();
        ISInterstitialScript = gameObject.GetComponentInChildren<IronSourceInterstitialScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        StartCoroutine(ClickRescaleCoroutine());
    }

    IEnumerator ClickRescaleCoroutine()
    {
        float counter = 0f;
        Vector3 endRescale = new Vector3(3, 3, 1);
        while (counter < duration)
        {
            gameObject.transform.localScale = Vector3.Lerp(originalScale, endRescale, counter / duration);
            yield return null;
            counter += Time.deltaTime;
        }
        counter = 0;
        while (counter < duration)
        {
            gameObject.transform.localScale = Vector3.Lerp(endRescale, originalScale, counter / duration);
            yield return null;
            counter += Time.deltaTime;
        }
        numberClicksText.text = (++numberClicks).ToString();
        UpdatePlayFabLeaderboard();

        if(numberClicks%10 == 0) callIronSourceEvent();

    }

    void callIronSourceEvent()
    {
        Dictionary<string, object> eventProps = new Dictionary<string, object>();
        eventProps.Add("Number Clicks", numberClicks);
        Amplitude.Instance.logEvent("CLICKED", eventProps);
        ISInterstitialScript.LoadInterstitial();
    }

    void UpdatePlayFabLeaderboard()
    {
        PBLeaderboard.UpdateClicksLeaderboard(numberClicks);
    }
}
