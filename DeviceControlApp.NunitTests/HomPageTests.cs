using DeviceControlApp.Core.Service;
using NUnit.Framework;
using DeviceControlApp.Core.ViewModel;
using NSubstitute;

namespace DeviceControlApp.NunitTests
{

    public class HomePageTests
    {
    
        [Test]
        public void When_app_load_first_time_name_field_should_be_empty()
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
            var homePageViewModel = new HomePageViewModel(fakePageService, unitTestFactory, dataStoreService);

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
            var fakePageService = new FakePageService();
            var _mockLocationService = Substitute.For<ILocationService>();
            var locationdumyService = Substitute.For<ILocationService>();
            var dataStoreService = Substitute.For<IDataStore>();
            var userName = "test";
            dataStoreService.IsDataAvailable("LoggedInUserName").Returns(false);
            dataStoreService.When(x => x.Put<string>("LoggedInUserName", userName)).Do(x =>
            {
                dataStoreService.IsDataAvailable("LoggedInUserName").Returns(true);
                dataStoreService.Get<string>("LoggedInUserName").Returns(userName);
            });
            var unitTestFactory = new UnitTestFactory((r) =>
            {
                r.RegisterSingleton<IPageService>(fakePageService);
                r.RegisterSingleton<ILocationService>(locationdumyService);
                r.RegisterSingleton<IDataStore>(dataStoreService);
            });
            var homePageViewModel = new HomePageViewModel(fakePageService, unitTestFactory, dataStoreService);
            homePageViewModel.Name = userName;
            homePageViewModel.GoToNextCommand.Execute(null);

            var productPageViewModel = new LocationViewModel(fakePageService, _mockLocationService, unitTestFactory, dataStoreService);
            var canGoBack = productPageViewModel.GoBackCommand.CanExecute(null);
            productPageViewModel.GoBackCommand.Execute(null);

            Assert.AreEqual(userName, homePageViewModel.Name);
           
        }
    }
}
