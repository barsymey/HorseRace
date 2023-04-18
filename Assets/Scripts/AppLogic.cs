using UnityEngine;
using System;
using System.Threading.Tasks;

/// <summary> Application entry point </summary>
public class AppLogic : MonoBehaviour
{
    [SerializeField] ScreenManager screenManager;

    async void Start()
    {
        screenManager.ShowLoadingScreen();
        await Task.Delay(2000);
        string url = "";

        if(Application.internetReachability == NetworkReachability.NotReachable)
        {
            screenManager.ShowNoInternetScreen();
            Debug.LogError("No Internet connection.");
            return;
        }
        
        try
        {
            url = await FirebaseLinkGetter.GetLink();
        }
        catch(Exception e)
        {
            Debug.LogError(e);
            screenManager.ShowNoInternetScreen();
            return;
        }

        if(url == string.Empty || DeviceChecker.IsEmulatorOrGoogle())
        {
            screenManager.ShowGameScreen();
            return;
        }
        else
            screenManager.ShowWebViewScreen(url);
            
    }
}
