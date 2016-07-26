using System;

namespace Simsip.Demo.ViewModels
{
    public delegate void ViewModelDisplayAlertEventHandler(object sender, ViewModelDisplayAlertEventArgs e);

    public class ViewModelDisplayAlertEventArgs : EventArgs
    {
        public string Title;
        public string Message;
        public string Cancel;
    }
}
