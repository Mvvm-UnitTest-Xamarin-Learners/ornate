﻿using System.Windows.Input;
using DeviceControlApp.Core.Service;
using DeviceControlApp.Core.ServiceImpln;

namespace DeviceControlApp.Core.ViewModel
{
    public class HomePageViewModel:BaseViewModel
    {
        public ICommand GoToNextCommand { get; private set; }

        private IPageService _pageService;
        public IDataStore _datastore;
        private readonly IFactory _factory;

        private string _name;
        public string Name
        {
            get => _name;
            set{
                _name = value;
                NotifyPropertyChanged();
                EnableButton(_name);
            }
        }

        private bool _isButtonenabled;
        public bool IsButtonEnabled
        {
            get => _isButtonenabled;
            set
            {
                _isButtonenabled = value;
                NotifyPropertyChanged();
            }
        }
        private void EnableButton(string name)
        {
            if (name.Length >= 3)
                IsButtonEnabled = true;
            else
                IsButtonEnabled = false;

        }

        public HomePageViewModel(IPageService pageService, IFactory factory,IDataStore dataStore)
        {
            IsButtonEnabled = false;
            _pageService = pageService;
            _factory = factory;
            _datastore = dataStore;
            if(!_datastore.IsContainsKey())
             Name = _datastore.Get<string>("Name");
            GoToNextCommand = new RelayCommand(GoToNextPage);
        }

        public async void GoToNextPage()
        {
            _datastore.Put("Name", Name);
            await _pageService.GoNext(_factory.Get<LocationViewModel>());
        }
    }
}