using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabLeaderBoard : MonoBehaviour
{
    private Text topUserText;
    private Text topClicksText;
    // Start is called before the first frame update
    void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            /*
            Please change the titleId below to your own titleId from PlayFab Game Manager.
            If you have already set the value in the Editor Extensions, this can be skipped.
            */
            PlayFabSettings.staticSettings.TitleId = "42";
        }
#if UNITY_EDITOR
        var request = new LoginWithCustomIDRequest { CustomId = "UnityEditor", CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
#elif PLATFORM_ANDROID
        var request = new LoginWithAndroidDeviceIDRequest { AndroidDeviceId = "AndroidPhone", CreateAccount = true };
        PlayFabClientAPI.LoginWithAndroidDeviceID(request, OnLoginSuccess, OnLoginFailure);
#endif

        topUserText = gameObject.GetComponentsInChildren<Text>()[1];
        topClicksText = gameObject.GetComponentsInChildren<Text>()[2];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetLeaderboardData()
    {
        GetLeaderboardRequest requestData = new GetLeaderboardRequest()
        {
            StatisticName = "Clicks",
            StartPosition = 0,
            MaxResultsCount = 1,
        };
        PlayFabClientAPI.GetLeaderboard(requestData, OnGetLeaderboardDataResult, OnGetLeaderboardDataError);
    }

    public void UpdateClicksLeaderboard(int numberClicks)
    {
        UpdatePlayerStatisticsRequest requestData = new UpdatePlayerStatisticsRequest()
        {
            Statistics = new List<StatisticUpdate>()
            {
                new StatisticUpdate() { StatisticName = "Clicks", Value = numberClicks }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(requestData, OnReportStatClicksResult, OnReportStatClicksError);

    }

    private void OnReportStatClicksResult(UpdatePlayerStatisticsResult response)
    {
        // Successfully Reported
    }

    private void OnReportStatClicksError(PlayFabError error)
    {
        Debug.Log(error.ErrorMessage);
    }

    private void OnGetLeaderboardDataResult(GetLeaderboardResult response)
    {
        foreach (var entry in response.Leaderboard)
        {
            Debug.Log(entry.Position + ". " + entry.DisplayName + " : " + entry.StatValue);
            topUserText.text = entry.DisplayName;
            topClicksText.text = entry.StatValue + " clicks";
            break;
        }
    }


    private void OnGetLeaderboardDataError(PlayFabError error)
    {
        Debug.Log(error.ErrorMessage);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        SetDisplayNameForUser();
        GetLeaderboardData();
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }

    private void SetDisplayNameForUser()
    {
#if UNITY_EDITOR
        var name = "UnityTestPlayer";
#elif PLATFORM_ANDROID
        var name = "AndroidTestPlayer";
#endif
        UpdateUserTitleDisplayNameRequest requestData = new UpdateUserTitleDisplayNameRequest()
        {
            DisplayName = name
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(requestData, OnSetDisplayNameForUserResult, OnSetDisplayNameForUserError);
    }

    private void OnSetDisplayNameForUserResult(UpdateUserTitleDisplayNameResult response)
    {

    }

    private void OnSetDisplayNameForUserError(PlayFabError error)
    {
        Debug.Log(error.ErrorMessage);
    }
}
