using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager singleton;

    [SerializeField] UIScreen loadingScreen;
    [SerializeField] UIScreen noInternetScreen;
    [SerializeField] UIScreen gameScreen;
    [SerializeField] WebViewScreen webViewScreen;

    void Start()
    {
        if(!singleton)
            singleton = this;
        else Destroy(this);
    }

    public void ShowLoadingScreen()
    {
        HideAllScreens();
        loadingScreen.Show();
    }

    public void ShowNoInternetScreen()
    {
        HideAllScreens();
        noInternetScreen.Show();
    }

    public void ShowGameScreen()
    {
        HideAllScreens();
        gameScreen.Show();
    }

    public void ShowWebViewScreen(string url)
    {
        HideAllScreens();
        webViewScreen.Show(url);
    }

    void HideAllScreens()
    {
        loadingScreen.Hide();
        noInternetScreen.Hide();
        gameScreen.Hide();
        webViewScreen.Hide();
    }
}
