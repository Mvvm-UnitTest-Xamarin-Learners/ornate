using System;
using NUnit.Framework;
using DeviceControlApp.Core.Service;
using DeviceControlApp.Core.ViewModel;
using NSubstitute;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DeviceControlApp.NunitTests
{
    public class GpsPageTest
    {
        private IPageService fakePageService;
        private IGpsSensorService gpsSensorService;
        private UnitTestFactory unitTestFactory;
        private GpsStatusViewModel gpsStatusViewModel;
        private ILocationService locationService;
       
        [SetUp]
        public void Setup()
        {
             fakePageService = new FakePageService();
            locationService = Substitute.For<ILocationService>();
            gpsSensorService = Substitute.For<IGpsSensorService>();
            unitTestFactory = new UnitTestFactory(r =>
            {
                r.RegisterSingleton<IPageService>(fakePageService);
                r.RegisterSingleton<ILocationService>(locationService);
                r.RegisterSingleton<IGpsSensorService>(gpsSensorService);
            });
            gpsStatusViewModel = new GpsStatusViewModel(fakePageService, gpsSensorService, unitTestFactory);
        }
        [Test]
        public void when_we_go_gpsStatusPage_status_intial_message_is_shown()
        {
            gpsStatusViewModel.Message = "Gps Location is available";
            Assert.AreEqual("Gps Location is available", gpsStatusViewModel.Message);
        }

        [Test]
        public void When_we_hit_back_then_we_go_home_page()
        {
            var canGoBack = gpsStatusViewModel.BackCommand.CanExecute(null);
            gpsStatusViewModel.BackCommand.Execute(null);

            Assert.AreEqual(true, canGoBack);
            Assert.AreEqual(typeof(LocationViewModel), ((FakePageService)fakePageService).GetViewModelPageType());
        }

        [Test]
        public void When_click_refresh_button_message_get_changed()
        {
            var refreshPage = gpsStatusViewModel.RefreshCommand.CanExecute(null);
            gpsStatusViewModel.RefreshCommand.Execute(null);

            Assert.AreEqual("Gps Location is Disabled", gpsStatusViewModel.Message);
        }
        
    }
}
