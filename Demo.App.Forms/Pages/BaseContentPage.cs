using Simsip.Demo;
using Xamarin.Forms;

namespace Models.Pages
{
    public class BaseContentPage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!(Application.Current as App).IsAuthenticated)
            {
                Navigation.PushModalAsync(new LoginPage());
            }
        }
    }
}