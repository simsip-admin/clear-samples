using Xamarin.Forms;

namespace Simsip.Demo.Cells
{
    public class HistoryCell : ViewCell
    {
        public HistoryCell ()
        {
            var nameLabel = new Label () {
                FontFamily = "HelveticaNeue-Medium",
                FontSize = 16,
                TextColor = Color.FromHex("#666")
            };
            nameLabel.SetBinding (Label.TextProperty, "EntryName");

            var dateLabel = new Label () {
                FontAttributes = FontAttributes.Bold,
                FontSize = 12,
                TextColor = Color.Black
            };
            dateLabel.SetBinding (Label.TextProperty, new Binding ("EntryDate", stringFormat: "{0:d}"));

            var valueLabel = new Label () { 
                TextColor = Color.Blue,
                FontSize = 12,
                HorizontalOptions = LayoutOptions.End
            };
            valueLabel.SetBinding(Label.TextProperty, new Binding("EntryValue", stringFormat: "{0:N}"));

            var valueLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { valueLabel },
                HorizontalOptions = LayoutOptions.EndAndExpand
            };

            var statusLayout = new StackLayout {
                Orientation = StackOrientation.Horizontal,
                Children = { dateLabel, valueLayout },
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var historyDetailsLayout = new StackLayout {
                Padding = new Thickness (10, 0, 0, 0),
                Spacing = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { nameLabel, statusLayout }
            };

            var cellLayout = new StackLayout {
                Spacing = 0,
                Padding = new Thickness (10, 5, 10, 5),
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { historyDetailsLayout }
            };
            cellLayout.SetBinding(StackLayout.BackgroundColorProperty, "Background");

            this.View = cellLayout;
        }
    }
}

