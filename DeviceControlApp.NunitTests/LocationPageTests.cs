using System;
using System.Diagnostics;
using System.Threading.Tasks;
using DeviceControlApp.Core.Service;
using DeviceControlApp.Core.ViewModel;
using NSubstitute;
using NUnit.Framework;

namespace DeviceControlApp.NunitTests
{
    public class LocationPageTests
    {
        private IPageService fakePageService;
        private ILocationService _mockLocationService;
        private UnitTestFactory unitTestFactory;
        private ProductViewModel productPageViewModel;

        [SetUp]
        public void Setup()
        {
            fakePageService= new FakePageService();
            _mockLocationService = Substitute.For<ILocationService>(); 
            unitTestFactory = new UnitTestFactory(r =>
            {
                r.RegisterSingleton<IPageService>(fakePageService);
                r.RegisterSingleton<ILocationService>(_mockLocationService);
            });
            productPageViewModel = new ProductViewModel(fakePageService, _mockLocationService, unitTestFactory);
        }


        [Test]
        public void When_we_go_to_location_page_initially_coordinates_are_empty()
        {
            _mockLocationService.GetLocation().Returns(Task.FromResult(new MyPosition { Latitude = String.Empty, Longitude = string.Empty }));
            Assert.IsTrue(String.IsNullOrWhiteSpace(productPageViewModel.Latitude));
            Assert.IsTrue(String.IsNullOrWhiteSpace(productPageViewModel.Longitude));
        }

        [Test]
        public void When_we_hit_get_location_then_location_is_displayed()
        {
            var latitude = "1.0";
            var longitude = "2.0";
            _mockLocationService.GetLocation().Returns(Task.FromResult(new MyPosition { Latitude=latitude, Longitude = longitude }));
            var canGetLocation = productPageViewModel.DisplayLocationCommand.CanExecute(null);
            Assert.AreEqual(true, canGetLocation);
            productPageViewModel.DisplayLocationCommand.Execute(null);
           
            Assert.AreEqual(latitude, productPageViewModel.Latitude);
            Assert.AreEqual(longitude, productPageViewModel.Longitude);
        }

        [Test]
        public void When_we_hit_clear_then_location_is_cleared()
        {
            var latitude = "1.0";
            var longitude = "2.0";
            _mockLocationService.GetLocation().Returns(Task.FromResult(new MyPosition { Latitude = latitude, Longitude = longitude }));

            var canGetLocation = productPageViewModel.DisplayLocationCommand.CanExecute(null);
            Assert.AreEqual(true, canGetLocation);

            productPageViewModel.DisplayLocationCommand.Execute(null);

            var canClearLocation = productPageViewModel.ClearLocationCommand.CanExecute(null);
            Assert.AreEqual(true, canClearLocation);
            productPageViewModel.ClearLocationCommand.Execute(null);

            Assert.IsTrue(String.IsNullOrWhiteSpace(productPageViewModel.Latitude));
            Assert.IsTrue(String.IsNullOrWhiteSpace(productPageViewModel.Longitude));

        }

        [Test]
        public void When_we_hit_back_then_we_go_home_page()
        {
            var canGoBack = productPageViewModel.GoBackCommand.CanExecute(null);
            productPageViewModel.GoBackCommand.Execute(null);

            Assert.AreEqual(true, canGoBack);
            Assert.AreEqual(typeof(HomePageViewModel), ((FakePageService)fakePageService).GetViewModelPageType());
        }
    }
}

