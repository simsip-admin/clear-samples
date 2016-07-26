using Xamarin.Forms;

namespace Simsip.Demo.Views
{
    public class FlashPassDetailsView : ContentView
	{
		public FlashPassDetailsView ()
		{
			var name = new Label () {
				Text = "Bill, would you like to upgrade to the Flash Pass?",
				FontSize = 20,
				FontFamily = Device.OnPlatform("HelveticaNeue-Bold","sans-serif-black",null),
				XAlign = TextAlignment.Center,
				TextColor = Color.Black
			};

			var stack = new StackLayout () {
				Padding = new Thickness(20,40),
				Children = {
					name
				}
			};

			Content = stack;
		}
	}
}