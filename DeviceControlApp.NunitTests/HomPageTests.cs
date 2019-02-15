using DeviceControlApp.Core.Service;
using NUnit.Framework;
using DeviceControlApp.Core.ViewModel;
using NSubstitute;
using System.Threading.Tasks;
using DeviceControlApp.Core.ServiceImpln;

namespace DeviceControlApp.NunitTests
{

    public class HomePageTests
    {
        private IPageService fakePageService;
        private IDataStore _mockDatastore;
        private UnitTestFactory unitTestFactory;
        private HomePageViewModel homePageViewModel;
        [SetUp]
        public void Setup()
        {
            fakePageService = new FakePageService();
            _mockDatastore = Substitute.For<IDataStore>();
            unitTestFactory = new UnitTestFactory(r =>
            {
                r.RegisterSingleton<IPageService>(fakePageService);
                r.RegisterSingleton<IDataStore>(_mockDatastore);
            });
            homePageViewModel = new HomePageViewModel(fakePageService, unitTestFactory, _mockDatastore);
        }
        [Test]
        public void When_app_load_first_time_name_field_should_be_empty()
        {
            Assert.IsTrue(string.IsNullOrEmpty(homePageViewModel.Name));
        }

        [Test]
        public void When_we_hit_next_then_we_go_to_location_page()
        {
            var fakePageService = new FakePageService();
            
            var locationdumyService = Substitute.For<ILocationService>();
            var dataStoreService = Substitute.For<IDataStore>();
            var unitTestFactory = new UnitTestFactory((r) =>
            {
                r.RegisterSingleton<IPageService>(fakePageService);
                r.RegisterSingleton<ILocationService>(locationdumyService);
                r.RegisterSingleton<IDataStore>(dataStoreService);
            });
            var homePageViewModel = new HomePageViewModel(fakePageService, unitTestFactory,dataStoreService);
            homePageViewModel.Name = "arun";
            var canGoNext = homePageViewModel.GoToNextCommand.CanExecute(null);
            homePageViewModel.GoToNextCommand.Execute(null);

            Assert.AreEqual(true, canGoNext);
            Assert.AreEqual(typeof(LocationViewModel), fakePageService.GetViewModelPageType());
        }
        [Test]
        public void When_we_come_back_to_home_page_name_should_be_there()
        {
            // _mockDatastore.Get<string>("Name").Returns(Task.FromResult(new DataStore().Put("Name", "demo")));
            _mockDatastore.Put("Name", "demo");
            _mockDatastore.IsDataAvailable("Names").Returns(true);

            Assert.AreEqual("demo", _mockDatastore.Get<string>("demo"));
        }
    }
}
