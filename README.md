# SDK-Circker
Unity 2d project as a playground to practice integrate differents SDKs into an Unity project.

## Integrated SDK

### Firebase for Unity SDK

> Replace your google-services at Assets/StreamingAssets

The project implements Firebase Analytics and Crashlytics.

If you click "Test Crash" button, it will trigger a crash that will send the event to Crashlytics.

### IronSource for Unity SDK with Unity Ads

> Replace the Iron Source App Key at the YOUR_APP_KEY in Iron Source Script in SDKManager object

Every 10 clicks a Interstitial Unity Ad will pop up, which is mediated via IronSource.

### Amplitude for Unity SDK

> Replace the Amplitude Key at Amplitude Key in Amplitude Init Script in SDKManager object

It will send "EVENT_NAME_HERE" at the start of the app and every 10 clicks will send "CLICKED" with the event Property of how many has been clicked.

### PlayFab for Unity SDK

> Login in the PlayFab tab with your data

At the start, the app will login and for each click, the user data "Clicks" will be updated with the number of clicks.
PlayFab will also load the leaderboard for "Clicks" and display the top 1. The update in-app of the leaderboard is done at the start of the app.
