using Simsip.Demo;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;

namespace Simsip.Demo.Pages
{
    public class DrawMomentPage : ContentPage
    {
        Image cancelButton, sendButton;
        TapGestureRecognizer cancelButtonTapped, sendButtonTapped;
        RelativeLayout mainLayout;
        byte[] image;

        public DrawMomentPage (byte[] image)
        {
            this.image = image;

            SetupUserInterface ();
            SetupEventHandlers ();
        }

        protected override void OnDisappearing ()
        {
            base.OnDisappearing ();

            cancelButton.IsVisible = true;
            sendButton.IsVisible = true;
        }

        private void SetupUserInterface ()
        {
            BackgroundColor = Color.Black;
            NavigationPage.SetHasNavigationBar (this, false);

            sendButton = new Image {
                Source = "SendMomentButton.png"
            };

            cancelButton = new Image {
                Source = "CancelButton.png",
                HorizontalOptions = LayoutOptions.Start,
                HeightRequest = 22,
                WidthRequest = 22
            };

            var moment = new Image {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Source = ImageSource.FromStream(() => new MemoryStream (this.image))
            };

            mainLayout = new RelativeLayout () {
                Padding = new Thickness (0)
            };

            mainLayout.Children.Add (moment, 
                Constraint.Constant (0), 
                Constraint.Constant (0), 
                Constraint.RelativeToParent ((parent) => { return parent.Width; }),
                Constraint.RelativeToParent ((parent) => { return parent.Height; }));

            mainLayout.Children.Add (cancelButton, 
                Constraint.RelativeToParent ((parent) => { return 15; }),
                Constraint.Constant (15),
                Constraint.Constant (30), 
                Constraint.Constant (30));

            mainLayout.Children.Add (sendButton, 
                Constraint.RelativeToParent ((parent) => { return parent.Width - 40; }),
                Constraint.RelativeToParent ((parent) => { return parent.Height - 40; }),
                Constraint.Constant (30), 
                Constraint.Constant (30));

            Content = mainLayout;
        }

        private void SetupEventHandlers ()
        {
            cancelButtonTapped = new TapGestureRecognizer ();
            cancelButtonTapped.Tapped += async (object sender, EventArgs e) => {
                await App.Current.MainPage.Navigation.PopModalAsync ();
            };
            cancelButton.GestureRecognizers.Add (cancelButtonTapped);

            sendButtonTapped = new TapGestureRecognizer ();
            sendButtonTapped.Tapped += async (object sender, EventArgs e) => {
                cancelButton.IsVisible = false;
                sendButton.IsVisible = false;

                // await Navigation.PushAsync (new SendMomentPage (new MemoryStream (image), ViewModel.DisplayTime));
                await Navigation.PushAsync(new FlashPassPage());
            };
            sendButton.GestureRecognizers.Add (sendButtonTapped);
        }
    }
}