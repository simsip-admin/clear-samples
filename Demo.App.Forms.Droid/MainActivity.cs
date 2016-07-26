using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using HockeyApp;

namespace Simsip.Demo.Droid
{
    [Activity(Label = "Clear", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            //
            // Begin HockeyApp
            // https://components.xamarin.com/gettingstarted/hockeyappandroid
            // Note: Using Nuget package
            //

            // AppID, not seen here, can be found in Properties/AssemblyInfo.cs
            CrashManager.Register(this);

            CheckForUpdates();

            //
            // End HockeyApp
            //

            // For Xamarin.UITest, allow UITest to query controls on Android.
            // https://developer.xamarin.com/guides/xamarin-forms/deployment,_testing,_and_metrics/uitest-and-test-cloud/
            Xamarin.Forms.Forms.ViewInitialized += (object sender, Xamarin.Forms.ViewInitializedEventArgs e) => {
                if (!string.IsNullOrWhiteSpace(e.View.AutomationId))
                {
                    e.NativeView.ContentDescription = e.View.AutomationId;
                }
            };

            LoadApplication(new App());
        }

        private void CheckForUpdates()
        {
            // TODO: Remove this for store builds!
            UpdateManager.Register(this);
        }

        private void UnregisterManagers()
        {
            UpdateManager.Unregister();
        }

        protected override void OnPause()
        {
            base.OnPause();

            UnregisterManagers();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            UnregisterManagers();
        }
    }
}

