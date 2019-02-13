using System;
using NUnit.Framework;
using DeviceControlApp.Core.Service;
using DeviceControlApp.Core.ViewModel;
using NSubstitute;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DeviceControlApp.NunitTests
{
    public class GivenGpsIsDisabledGpsPageTests
    {
        private IPageService fakePageService;
        private IGpsSensorService gpsSensorService;
        private UnitTestFactory unitTestFactory;
        private GpsStatusViewModel gpsStatusViewModel;
        private ILocationService locationService;
        private IDataStore _datastore;

        [SetUp]
        public void Setup()
        {
            fakePageService = new FakePageService();
            _datastore = Substitute.For<IDataStore>();
            locationService = Substitute.For<ILocationService>();
            gpsSensorService = Substitute.For<IGpsSensorService>();
            gpsSensorService.IsGpsEnabled().Returns(false);
            unitTestFactory = new UnitTestFactory(r =>
            {
                r.RegisterSingleton<IPageService>(fakePageService);
                r.RegisterSingleton<ILocationService>(locationService);
                r.RegisterSingleton<IGpsSensorService>(gpsSensorService);
                r.RegisterSingleton<IDataStore>(_datastore);
            });
            gpsStatusViewModel = new GpsStatusViewModel(fakePageService, gpsSensorService, unitTestFactory, _datastore);
        }
        [Test]
        public void when_we_go_gps_statusPage_status_intial_message_is_shown()
        {
           
            Assert.AreEqual("Gps Location is Disabled", gpsStatusViewModel.Message);
        }

        [Test]
        public void When_we_hit_back_then_we_go_location_page()
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

        [Test]
        public void When_gps_is_enabled_and_page_is_refreshed_then_enable_message_is_shown()
        {
            gpsSensorService.IsGpsEnabled().Returns(true);
            var refreshPage = gpsStatusViewModel.RefreshCommand.CanExecute(null);
            gpsStatusViewModel.RefreshCommand.Execute(null);

            Assert.AreEqual("Gps Location is Avilable", gpsStatusViewModel.Message);
        }
    }
}
