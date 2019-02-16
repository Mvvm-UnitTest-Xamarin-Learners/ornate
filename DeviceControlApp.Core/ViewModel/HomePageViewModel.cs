using System;
using System.Diagnostics;
using System.Windows.Input;
using DeviceControlApp.Core.Service;
using DeviceControlApp.Core.ServiceImpln;


namespace DeviceControlApp.Core.ViewModel
{
    public class HomePageViewModel:BaseViewModel
    {
      
        public RelayCommand GoToNextCommand { get; private set; }
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

                GoToNextCommand.RaiseCanExecuteChanged();

            }
        }

        public HomePageViewModel(IPageService pageService, IFactory factory, IDataStore dataStore)
        {
          
            _pageService = pageService;
            _factory = factory;
            _datastore = dataStore;

            GoToNextCommand = new RelayCommand(GoToNextPage, CanExecuteGoToNextCommand);
            if (_datastore.IsDataAvailable("LoggedInUserName"))
                Name = _datastore.Get<string>("LoggedInUserName");
        }

        public bool CanExecuteGoToNextCommand()
        {
            if (string.IsNullOrEmpty(Name))
            {

                return false;
            }
            if (Name.Length >= 3)
                return true;
            return false;
        }

        public async void GoToNextPage()
        {
            _datastore.Put("LoggedInUserName", Name);
            await _pageService.GoNext(_factory.Get<LocationViewModel>());
        }
    }
}