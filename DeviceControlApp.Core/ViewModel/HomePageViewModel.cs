using System.Windows.Input;
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

        public HomePageViewModel(IPageService pageService, IFactory factory,IDataStore dataStore)
        {
            _pageService = pageService;
            _factory = factory;
            _datastore = dataStore;
            GoToNextCommand = new RelayCommand(GoToNextPage);
        }

        public async void GoToNextPage()
        {

            _datastore.Put("Name", Name);
            
            await _pageService.GoNext(_factory.Get<LocationViewModel>());
        }
    }
}