using Simsip.Demo.Cells;
using Simsip.Demo.Models;
using Xamarin.Forms;


namespace Simsip.Demo.Pages
{
    public class HistoryPage : ContentPage
	{
		public HistoryPage ()
		{
			Title = "All set Bill!";

            BackgroundImage = "six_flags_park.jpg";

            var timeLabel = new Label()
            {
                FontFamily = "HelveticaNeue-Medium",
                FontSize = 12,
                TextColor = Color.Black,
                Text = "Welcome back Bill, would you like to upgrade to the Flash Pass?",
                VerticalTextAlignment = TextAlignment.Center
            };

            var timeLabel2 = new Label()
            {
                FontFamily = "HelveticaNeue-Medium",
                FontSize = 12,
                TextColor = Color.Black,
                Text = "Clear customers get extended discounts on the Flash Pass.",
                VerticalTextAlignment = TextAlignment.Center
            };

            var flashPassImage = new Image()
            {
                Source = new FileImageSource() { File = "flashpass.jpg" },
                Aspect = Aspect.AspectFit
            };
            
            var layout = new StackLayout
            {
				Children =
                {
                    timeLabel,
                    timeLabel2,
					flashPassImage
				}
			};

			Content = layout;
		}
	}
}