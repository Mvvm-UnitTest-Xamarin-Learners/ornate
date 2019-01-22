using System;
using System.Windows.Input;
using DeviceControlApp.Services;
using DeviceControlApp.View;
using Xamarin.Forms;

namespace DeviceControlApp.ViewModel
{
    public class HomePageViewModel
    {
        public ICommand GoToNextCommand { get; private set; }  
      
        private IPageService _pageService;

        private ILocationService _locationService;

        public HomePageViewModel(IPageService pageService,ILocationService locationService)
        {
            _pageService = pageService;
            _locationService = locationService;
            GoToNextCommand = new Command(GoToNextPage);
        }

        public async void GoToNextPage()
        {
            var viewModel = new ProductViewModel(_pageService,_locationService);
            await _pageService.GoNext(viewModel);
        }
    }
}
