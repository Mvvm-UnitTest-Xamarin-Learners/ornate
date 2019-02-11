using System.Windows.Input;
using DeviceControlApp.Core.Service;

namespace DeviceControlApp.Core.ViewModel
{
    public class HomePageViewModel
    {
        public ICommand GoToNextCommand { get; private set; }

        private IPageService _pageService;
        private readonly IFactory _factory;
        
        public HomePageViewModel(IPageService pageService, IFactory factory)
        {
            _pageService = pageService;
            _factory = factory;
            GoToNextCommand = new RelayCommand(GoToNextPage);
        }

        public async void GoToNextPage()
        {
            await _pageService.GoNext(_factory.Get<LocationViewModel>());
        }
    }
}