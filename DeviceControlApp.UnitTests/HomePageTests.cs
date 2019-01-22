using System.Threading.Tasks;
using DeviceControlApp.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DeviceControlApp.UnitTests
{
    [TestClass]
    public class HomePageTests
    {
        [TestMethod]
        public void When_we_hit_next_then_we_go_to_location_page()
        {
            var dummyPageService = new DummyPageService();
            var locationdumyService = new DummyLocationService();
            var homePageViewModel = new HomePageViewModel(dummyPageService,locationdumyService);
            var canGoNext = homePageViewModel.GoToNextCommand.CanExecute(null);
            homePageViewModel.GoToNextCommand.Execute(null);

            Assert.AreEqual(true, canGoNext);
            Assert.AreEqual(typeof(ProductViewModel), dummyPageService.GetViewModelPageType());
        }
    }
}
