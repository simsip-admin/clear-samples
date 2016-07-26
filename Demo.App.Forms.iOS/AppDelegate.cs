using Foundation;
using UIKit;
using Xamarin.Forms;

namespace Simsip.Demo.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            //
            // Begin HockeyApp
            // https://components.xamarin.com/gettingstarted/hockeyappandroid
            // Note: Using Nuget package
            //

            // Nuget package currently does not build, leaving this here for when Nuget stabilizes
            // https://www.nuget.org/packages/HockeySDK.Xamarin
            /*
            var manager = BITHockeyManager.SharedHockeyManager;
            manager.Configure("cc8f4192f56c473b9b048a6a7ec4b540");
            manager.StartManager();
            */

            //
            // End HockeyApp
            //

            // For Xamarin.UITest, copy the AutomationId into the AccessibilityIdentifier each time a view is initialized.
            // https://developer.xamarin.com/guides/xamarin-forms/deployment,_testing,_and_metrics/uitest-and-test-cloud/
            Forms.ViewInitialized += (object sender, ViewInitializedEventArgs e) => {
                // http://developer.xamarin.com/recipes/testcloud/set-accessibilityidentifier-ios/
                if (null != e.View.AutomationId)
                {
                    e.NativeView.AccessibilityIdentifier = e.View.AutomationId;
                }
            };

            // The Calabash DLL makes uses of non public Apple API's which will cause your app to be rejected by the App Store. 
            // The Xamarin.iOS linker will remove the Calabash DLL from the final IPA if it not explicitly referenced anywhere
            // by the code. Release builds do not have the ENABLE_TEST_CLOUD compiler variable, which will cause the Calabash DLL
            // to be removed from app bundle. Debug builds will have the compiler directive defined, preventing the linker from 
            // removing the Calabash DLL.
            // https://developer.xamarin.com/guides/xamarin-forms/deployment,_testing,_and_metrics/uitest-and-test-cloud/
#if ENABLE_TEST_CLOUD
            // requires Xamarin Test Cloud Agent
            Xamarin.Calabash.Start();
#endif

            return base.FinishedLaunching(app, options);
        }
    }
}
