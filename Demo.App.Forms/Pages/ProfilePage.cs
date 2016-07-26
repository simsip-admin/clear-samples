using Models.Models.Types;
using Models.Refit;
using Models.Services;
using Refit;
using Simsip.Demo;
using System;
using System.Diagnostics;
using Xamarin.Forms;


namespace Models.Pages
{
    public class ProfilePage : BaseContentPage
    {
        public ProfilePage()
        {
            // Using messaging center to ensure that content only gets loaded once authentication is successful.
            // Once Xamarin.Forms adds more support for view life cycle events, this kind of thing won't be as necessary.
            // The OnAppearing() and OnDisappearing() overrides just don't quite cut the mustard yet, nor do the Appearing and Disappearing delegates.
            MessagingCenter.Subscribe<App>(this, "Authenticated", (sender) =>
            {
                Content = new Label()
                {
                    Text = "Profile Page",
                    XAlign = TextAlignment.Center,
                    YAlign = TextAlignment.Center
                };

                GetChannels();
            });
        }

        async void GetChannels()
        {
            try
            {
                var settings = new RefitSettings 
                { 
                    UrlParameterFormatter = new CustomUrlParameterFormatter() 
                };
                var api = RestService.For<IChannels>( ("https://slack.com/api/"), settings);

                var channels = await api.ChannelsList();
                foreach(Channel channel in channels.Channels)
                {
                    Debug.WriteLine(channel.Name);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Exception: " + ex);
            }
        }
    }
}
