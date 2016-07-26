using System;
using Android.App;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using Models;
using Models.Pages;
using Simsip.Demo;

[assembly: ExportRenderer(typeof(LoginPage), typeof(Models.Droid.Renderers.LoginPageRenderer))]

namespace Models.Droid.Renderers
{
    public class LoginPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
        
            var activity = this.Context as Activity;

            var auth = new OAuth2Authenticator(
                clientId: App.Instance.OAuthSettings.ClientId,
                clientSecret: App.Instance.OAuthSettings.ClientSecret,
                scope: App.Instance.OAuthSettings.Scope,
                accessTokenUrl: new Uri(App.Instance.OAuthSettings.AccessTokenUrl),
                authorizeUrl: new Uri(App.Instance.OAuthSettings.AuthorizeUrl),
                redirectUrl: new Uri(App.Instance.OAuthSettings.RedirectUrl));


            auth.Completed += (sender, eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {
                    App.Instance.SuccessfulLoginAction.Invoke();
                    // Use eventArgs.Account to do wonderful things
                    App.Instance.SaveToken(eventArgs.Account.Properties["access_token"]);
                }
                else
                {
                    // The user cancelled
                }
            };

            activity.StartActivity(auth.GetUI(activity));
        }
    }
}