using Xamarin.Forms;

namespace Simsip.Demo.Views
{
    public class MainDetailsView : ContentView
	{
		public MainDetailsView ()
		{
			var name = new Label () {
				Text = "Tap and hold for face recognition",
				FontSize = 20,
				FontFamily = Device.OnPlatform("HelveticaNeue-Bold","sans-serif-black",null),
				XAlign = TextAlignment.Center,
				TextColor = Color.Black
			};

			var where = new Label () {
				Text = "Powered by Clear",
				FontSize = 12,
				FontFamily = Device.OnPlatform("HelveticaNeue-Light","sans-serif-light",null),
				XAlign = TextAlignment.Center,
				TextColor = Color.FromHex("#666")
			};

			var bio = new Label () {
				Text = "There are no park alerts.",
				FontSize = 14,
				FontFamily = Device.OnPlatform("HelveticaNeue","sans-serif",null),
				XAlign = TextAlignment.Center,
				TextColor = Color.Black
			};

			var stack = new StackLayout () {
				Padding = new Thickness(20,40),
				Children = {
					name,
					where,
					bio
				}
			};

			Content = stack;
		}
	}
}