using System;
using System.Windows.Input;
using DeviceControlApp.Core.Service;

namespace DeviceControlApp.Core.ViewModel
{
    public class LocationStatusViewModel:BaseViewModel
    {
        public ICommand BackCommand { get; private set; }
        public ICommand RefreshCommand{ get; private set; }
        private readonly IFactory _factory;
        public IPageService _pageService;
        public ILocationService _locationService;

        private string _message;
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                NotifyPropertyChanged();
            }

        }
        public LocationStatusViewModel(IPageService pageService,ILocationService locationService,IFactory factory)
        {
             
            _factory = factory;
            _pageService = pageService;
            _locationService = locationService;
             CheckLocationServiceisEnabled();
            BackCommand = new RelayCommand(GoToProductPage);
            RefreshCommand = new RelayCommand(CheckLocationServiceisEnabled);
        }

        private void GoToProductPage()
        {
            _pageService.GoNext(_factory.Get<ProductViewModel>());
        }
        private void CheckLocationServiceisEnabled()
        {
            if(_locationService.CheckGpsEnabled())
            {
                Message = "Gps Location is Avilable";
            }
            else
            {
                Message = "Gps Location is Disabled";
            }
        }
    }
}
