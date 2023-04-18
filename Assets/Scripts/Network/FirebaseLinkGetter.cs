using Firebase.Extensions;
using Firebase.RemoteConfig;
using System;
using UnityEngine;
using System.Threading.Tasks;

public class FirebaseLinkGetter
{
    private const string urlName = "url";

    public static async Task<string> GetLink(){
        string url = GetLocalLInk();
        if(url != string.Empty)
        {
            return url;
        }
        Debug.Log("Fetching data...");
        Task fetchTask = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.FetchAsync(TimeSpan.Zero);
        await fetchTask.ContinueWithOnMainThread(FetchComplete);
        url = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.AllValues[urlName].StringValue;
        SaveLocalLink(url);
        return url;
    }

    private static void FetchComplete(Task fetchTask) {
        if (!fetchTask.IsCompleted) {
            Debug.LogError("Retrieval hasn't finished.");
            return;
        }

        var remoteConfig = FirebaseRemoteConfig.DefaultInstance;
        var info = remoteConfig.Info;
        if(info.LastFetchStatus != LastFetchStatus.Success) {
            Debug.LogError($"{nameof(FetchComplete)} was unsuccessful\n{nameof(info.LastFetchStatus)}: {info.LastFetchStatus}");
            return;
        }

        // Fetch successful. Parameter values must be activated to use.
        remoteConfig.ActivateAsync()
            .ContinueWithOnMainThread(
            task => {
                Debug.Log($"Remote data loaded and ready for use. Last fetch time {info.FetchTime}.");
            });
    }

    private static string GetLocalLInk()
    {
        return PlayerPrefs.GetString(urlName, string.Empty);
    }

    private static void SaveLocalLink(string link)
    {
        PlayerPrefs.SetString(urlName, link);
    }
}
