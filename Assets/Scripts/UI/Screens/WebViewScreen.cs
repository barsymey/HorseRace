using UnityEngine;

public class WebViewScreen : UIScreen
{
    private WebViewBehaviour _webViewBehaviour;

    void Awake()
    {
        _webViewBehaviour = GetComponent<WebViewBehaviour>();
    }

    public void Show(string url)
    {
        base.Show();
       _webViewBehaviour.OpenPage(url);
    }
}
