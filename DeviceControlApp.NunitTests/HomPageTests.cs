using DeviceControlApp.Core.Service;
using NUnit.Framework;
using DeviceControlApp.Core.ViewModel;
using NSubstitute;

namespace DeviceControlApp.NunitTests
{

    public class HomePageTests
    {

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
            var canGoNext = homePageViewModel.GoToNextCommand.CanExecute(null);
            homePageViewModel.GoToNextCommand.Execute(null);

            Assert.AreEqual(true, canGoNext);
            Assert.AreEqual(typeof(LocationViewModel), fakePageService.GetViewModelPageType());
        }
    }
}
