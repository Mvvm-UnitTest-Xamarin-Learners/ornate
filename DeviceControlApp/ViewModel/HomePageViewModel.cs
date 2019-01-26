using System;
using System.Windows.Input;
using DeviceControlApp.Core;
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
            TestStatic.MyInt = 6;
            if (TestStatic.MyInt != 6) throw new Exception("Static is not working");

            TestObject testObject1 = new TestObject();
            testObject1.MyInt = 9;

            TestObject testObject2 = new TestObject();
            testObject2.MyInt = 10;

            if (testObject1.MyInt != 9) throw new Exception("Object is not working");



            _pageService = pageService;
            _locationService = locationService;
            GoToNextCommand = new RelayCommand(GoToNextPage);



        }

        public async void GoToNextPage()
        {
            var viewModel = new ProductViewModel(_pageService, _locationService);
            await _pageService.GoNext(viewModel);
        }
    }
}
