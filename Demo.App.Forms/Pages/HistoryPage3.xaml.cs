using Simsip.Demo.Models;
using Simsip.Demo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Simsip.Demo.Pages
{
    public partial class HistoryPage3 : ContentPage
    {
        private HistoryViewModel _vm;

        public HistoryPage3()
        {
            InitializeComponent();

            _vm = new HistoryViewModel();
            BindingContext = _vm;

            var accountItems = accountPicker.Items;
            accountItems.Add("0000.9645.3254");
            accountItems.Add("1000.8239.5216");
            accountItems.Add("0000.6924.8259");
            accountPicker.SelectedIndex = 0;

            var timeItems = timePicker.Items;
            timeItems.Add("Last 30 days");
            timeItems.Add("Last 3 months");
            timeItems.Add("Last 6 months");
            timePicker.SelectedIndex = 0;
        }
    }
}
