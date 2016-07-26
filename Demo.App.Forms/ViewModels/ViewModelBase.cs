using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Simsip.Demo.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T _p_Storage, T _p_Value, 
                                      [CallerMemberName] string _p_PropertyName = null)
        {
            if (object.Equals(_p_Storage, _p_Value))
                return false;

            _p_Storage = _p_Value;
            OnPropertyChanged(_p_PropertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string _p_PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_p_PropertyName));
        }
    }
}
