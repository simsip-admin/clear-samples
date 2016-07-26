using Models;
using Simsip.Demo.Pages;
using System;
using Xamarin.Forms;


// Dummy change
// Another dummy change

namespace Simsip.Demo
{
    public class App : Application
    {
        public static App Instance;

        public App()
        {
            MainPage = new NavigationPage(new MainPage());

            /* XAuth implementation
            App.Instance = this;

            OAuthSettings = new OAuthSettings(
                clientId: "14068036295.14069734496",
                clientSecret: "c8663f00e12aa2957feb82a8780c4e85",
                scope: "channels:read chat:write:user",
                authorizeUrl: "https://slack.com/oauth/authorize",
                redirectUrl: "https://simsip.azure-mobile.net/",
                accessTokenUrl: "https://slack.com/api/oauth.access");

            var profilePage = new ProfilePage();
            MainPage = new NavigationPage(profilePage);
            */
        }

        // XAuth implementation
        public OAuthSettings OAuthSettings { get; private set; }
        public bool IsAuthenticated
        {
            get { return !string.IsNullOrWhiteSpace(_token); }
        }

        string _token;
        public string Token
        {
            get { return _token; }
        }

        public void SaveToken(string token)
        {
            _token = token;

            // broadcast a message that authentication was successful
            MessagingCenter.Send<App>(this, "Authenticated");
        }

        public Action SuccessfulLoginAction
        {
            get
            {
                return new Action(() => MainPage.Navigation.PopModalAsync());
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
