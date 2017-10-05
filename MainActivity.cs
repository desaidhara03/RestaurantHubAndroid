using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Webkit;
using Android.Net.Http;

namespace RestHubDroidApp
{
    [Activity(Label = "RestHubDroidApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
     //   int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            WebView myWebView = (WebView) FindViewById(Resource.Id.webview);
            myWebView.Settings.SetGeolocationEnabled(true);
            myWebView.Settings.JavaScriptEnabled = true;
            myWebView.SetWebViewClient(new CustomWebViewClient()); // This is required to prevent navigation to chrome on click.
            myWebView.SetWebChromeClient(new CustomWebChromeClient()); // This is required to enable gps.

            //myWebView.LoadUrl("http://192.168.0.115:5771/");
            //myWebView.LoadUrl("http://10.248.9.21:5771/");

            //myWebView.LoadUrl("http://10.248.8.218:5771/");

             //myWebView.LoadUrl("http://customerhub.azurewebsites.net");
            myWebView.LoadUrl("https://customerhub.azurewebsites.net/customers/login");
        }
    }

    public class CustomWebChromeClient : WebChromeClient // This is required for auto allowing GPS permission.
    {
        override
        public void OnGeolocationPermissionsShowPrompt(string origin, GeolocationPermissions.ICallback callback)
        {
            // callback.invoke(String origin, boolean allow, boolean remember);
            callback.Invoke(origin, true, false);
        }
    }

    public class CustomWebViewClient : WebViewClient
    {
        override
        public void OnReceivedSslError(WebView view, SslErrorHandler handler, SslError error)
        {
            handler.Proceed(); // Ignore SSL certificate errors
        }
    }
}

