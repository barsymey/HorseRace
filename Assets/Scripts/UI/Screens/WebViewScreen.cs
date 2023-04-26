using UnityEngine.Android;
using System;

public class WebViewScreen : UIScreen
{
    private UniWebView _webViewBehaviour;

    void Awake()
    {
        _webViewBehaviour = GetComponent<UniWebView>();
    }

    public void Show(string url)
    {
        UniWebView.SetAllowAutoPlay(true);
        UniWebView.SetAllowInlinePlay(true);
        Permission.RequestUserPermission(Permission.Camera);
        _webViewBehaviour.AddPermissionTrustDomain(new Uri(url).Host);
        base.Show();
        _webViewBehaviour.Show();
       _webViewBehaviour.Load(url);
    }

    public override void Hide()
    {
        base.Hide();
        _webViewBehaviour.Hide();
    }
}
