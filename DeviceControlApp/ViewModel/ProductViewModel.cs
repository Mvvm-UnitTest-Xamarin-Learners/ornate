using System;
using System.Threading.Tasks;
using System.Windows.Input;
using DeviceControlApp.Services;
using DeviceControlApp.View;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;

namespace DeviceControlApp.ViewModel
{
    public class ProductViewModel:BaseViewModel
    {
       
        public ICommand GoBackCommand { get; private set; }
        public ICommand DisplayLocationCommand { get; private set; }
        public ICommand ClearLocationCommand { get; private set; }
        public IPageService _pageService;
        public ILocationService _locationService;

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
        private bool _flag;
        public bool Flag
        {
            get => _flag;
            set
            {
                _flag = value;
                NotifyPropertyChanged();
            }
        }

        public ProductViewModel(IPageService pageService,ILocationService locationService)
        {
            _pageService = pageService;
            _locationService = locationService;
          
            GoBackCommand = new Command(GoToHomePage);
            DisplayLocationCommand = new Command(() => { DisplayLocation(); });
            ClearLocationCommand = new Command(ClearLocation);
        }

        private void ClearLocation()
        {
            Latitude = "";
            Longitude = "";
            Flag = false;
        }

        private async void DisplayLocation() 
        {
            var myLocation = await _locationService.GetLocation();
            Latitude = myLocation.Latitude;
            Longitude = myLocation.Longitude;
            Flag = true;
        }


        public void GoToHomePage() 
        {
            var viewModel = new HomePageViewModel(_pageService,_locationService);
            _pageService.GoNext(viewModel);
        }
    }
}
