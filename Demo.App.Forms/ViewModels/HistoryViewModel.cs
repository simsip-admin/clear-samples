using Simsip.Demo.Data;
using Simsip.Demo.Models;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Simsip.Demo.ViewModels
{

    public class HistoryViewModel : ViewModelBase
    {
        private IList<History> _historyList;
        private IHistoryRepository _historyRepository;

        public HistoryViewModel()
        {
            _historyRepository = new HistoryRepository();
            InitializeHistoryDatabase();

            _historyList = _historyRepository.GetItems();
            InitializeBackgrounds();

            HistoryEntrySelectedCommand = new Command<History>(
                execute: (History historyItem) =>
                {
                    System.Diagnostics.Debug.WriteLine("History item selected");
                });
        }

        #region Properties

        public IList<History> HistoryList
        {
            private set { SetProperty(ref _historyList, value); }
            get { return _historyList; }
        }

        #endregion

        #region Commands

        public ICommand HistoryEntrySelectedCommand { private set; get; }

        #endregion

        #region Events

        public event ViewModelDisplayAlertEventHandler DisplayAlert;

        public EventHandler PopAsync;

        #endregion

        #region API

        public void RefreshCanExecutes()
        {
            ((Command)HistoryEntrySelectedCommand).ChangeCanExecute();
        }

        #endregion

        #region Helper methods

        private void FireDisplayAlert(string _p_Title, string _p_Message, string _p_Cancel)
        {
            DisplayAlert?.Invoke(this,
                new ViewModelDisplayAlertEventArgs
                {
                    Title = _p_Title,
                    Message = _p_Message,
                    Cancel = _p_Cancel
                });
        }

        private void FirePopAsync()
        {
            PopAsync?.Invoke(this, EventArgs.Empty);
        }

        private void InitializeHistoryDatabase()
        {
            if (_historyRepository.Count() <= 0)
            {
                var historyList = HistoryData.GetData();
                foreach(var historyEntry in historyList)
                {
                    _historyRepository.SaveItem(historyEntry);
                }
            }
        }

        private void InitializeBackgrounds()
        {
            for(int i = 0; i < _historyList.Count; i++)
            {
                if (i%2 == 0)
                {
                    _historyList[i].Background = Color.White;
                }
                else
                {
                    _historyList[i].Background = Color.FromHex("E9E9E9");
                }
            }
        }

        #endregion
    }
}
