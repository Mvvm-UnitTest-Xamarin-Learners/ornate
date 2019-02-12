using System;
using System.Windows.Input;
using DeviceControlApp.Core.Service;
using DeviceControlApp.Core.ServiceImpln;

namespace DeviceControlApp.Core.ViewModel
{
    public class LocationViewModel : BaseViewModel
    {
        public ICommand GoBackCommand { get; private set; }
        public ICommand DisplayLocationCommand { get; private set; }
        public ICommand ClearLocationCommand { get; private set; }
        public ICommand NextPageCommand { get; private set; }
        public IPageService _pageService;
        public ILocationService _locationService;
        private readonly IFactory _factory;
        public IDataStore _dataStore;
        private string _latitude;
        public string Latitude
        {
            get => _latitude;
            set
            {
                _latitude = value;
                NotifyPropertyChanged();
            }

        }
       
        public string Name {
            get;
            set;
           
        }



        private string _longitude;
        public string Longitude
        {

            get => _longitude;
            set
            {
                _longitude = value;
                NotifyPropertyChanged();
            }
        }

        public LocationViewModel(IPageService pageService, ILocationService locationService, IFactory factory,IDataStore dataStore)
        {
            _pageService = pageService;
            _locationService = locationService;
            _factory = factory;
            _dataStore = dataStore;
            Name = _dataStore.Get<string>("Name");
            GoBackCommand = new RelayCommand(GoToHomePage);
            ClearLocationCommand = new RelayCommand(ClearLocation);
            DisplayLocationCommand = new RelayCommand(DisplayLocation);
            NextPageCommand = new RelayCommand(GoToLocationStatusPage);

        }
       
        private void ClearLocation()
        {
            Latitude = "";
            Longitude = "";
            Flag = false;
        }

        private void GoToHomePage()
        {
            _pageService.GoNext(_factory.Get<HomePageViewModel>());
        }

        private void GoToLocationStatusPage()
        {
            _pageService.GoNext(_factory.Get<GpsStatusViewModel>());
        }

        private async void DisplayLocation()
        {
            try
            {
                var myLocation = await _locationService.GetLocation();
                Latitude = myLocation.Latitude;
                Longitude = myLocation.Longitude;
                Flag = true;
            }
            catch(Exception e)
            {

            }
        }
    }
}