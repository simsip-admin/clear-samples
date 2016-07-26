using Simsip.Demo.Pages;
using Xamarin.Forms;


namespace Simsip.Demo.Views
{
    public class MainSlideShowView : ContentView
	{
		public MainSlideShowView ()
		{
			HeightRequest = 200;

			var imgHistory = new Image() { Source = new FileImageSource(){ File = "menu_history.jpg"}};
			var imgOrderStatus = new Image() {Source = new FileImageSource(){ File = "menu_order_status.jpg"}};
			var imgQuotes = new Image() {Source = new FileImageSource(){ File = "menu_quotes.jpg"}};
			var imgChat = new Image() {Source = new FileImageSource(){ File = "menu_chat.jpg"}};

            var tapGestureRecognizerHistory = new TapGestureRecognizer();
            tapGestureRecognizerHistory.Tapped += (s, e) => 
                {
                    Navigation.PushAsync(new FlashPassPage());
                };
            imgHistory.GestureRecognizers.Add(tapGestureRecognizerHistory);

            var tapGestureRecognizerOrderStatus = new TapGestureRecognizer();
            tapGestureRecognizerOrderStatus.Tapped += (s, e) =>
            {
                Navigation.PushAsync(new HistoryPage());
            };
            imgOrderStatus.GestureRecognizers.Add(tapGestureRecognizerOrderStatus);

            var tapGestureRecognizerQuotes = new TapGestureRecognizer();
            tapGestureRecognizerQuotes.Tapped += (s, e) =>
            {
                Navigation.PushAsync(new HistoryPage());
            };
            imgQuotes.GestureRecognizers.Add(tapGestureRecognizerHistory);

            var tapGestureRecognizerChat = new TapGestureRecognizer();
            tapGestureRecognizerChat.Tapped += (s, e) =>
            {
                Navigation.PushAsync(new HistoryPage());
            };
            imgChat.GestureRecognizers.Add(tapGestureRecognizerHistory);

            var lblHistory = new Label()
            {
                Text = "History",
                FontSize = 12,
                FontFamily = Device.OnPlatform("HelveticaNeue-Light", "sans-serif-light", null),
                XAlign = TextAlignment.Center,
                TextColor = Color.FromHex("#666")
            };

            var lblOrderStatus = new Label()
            {
                Text = "OrderStatus",
                FontSize = 12,
                FontFamily = Device.OnPlatform("HelveticaNeue-Light", "sans-serif-light", null),
                XAlign = TextAlignment.Center,
                TextColor = Color.FromHex("#666")
            };

            var lblQuotes = new Label()
            {
                Text = "Quotes",
                FontSize = 12,
                FontFamily = Device.OnPlatform("HelveticaNeue-Light", "sans-serif-light", null),
                XAlign = TextAlignment.Center,
                TextColor = Color.FromHex("#666")
            };

            var lblChat = new Label()
            {
                Text = "Chat",
                FontSize = 12,
                FontFamily = Device.OnPlatform("HelveticaNeue-Light", "sans-serif-light", null),
                XAlign = TextAlignment.Center,
                TextColor = Color.FromHex("#666")
            };


            var stackHistory = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Children = {
                    imgHistory,
                    lblHistory
                }
            };

            var stack = new StackLayout () {
				Padding = new Thickness(0,0,0,10),
				Orientation = StackOrientation.Horizontal,
				Spacing = 10,
				Children = {
                    imgHistory,
					imgOrderStatus,
					imgQuotes,
					imgChat
				}
			};

			Content = new ScrollView() {
				Content = stack, 
				Orientation = ScrollOrientation.Horizontal};
		}
	}
}