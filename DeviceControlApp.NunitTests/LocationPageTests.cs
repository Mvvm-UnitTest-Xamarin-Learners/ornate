using System;
using System.Threading.Tasks;
using DeviceControlApp.Core.Service;
using DeviceControlApp.Core.ViewModel;
using NSubstitute;
using NUnit.Framework;

namespace DeviceControlApp.NunitTests
{
    public class LocationPageTests
    {
        private IPageService dummyPageService;
        private ILocationService dummyLocationService;
        private UnitTestFactory unitTestFactory;
        private ProductViewModel productPageViewModel;

        [SetUp]
        public void Setup()
        {
            dummyPageService = new FakePageService();
            dummyLocationService = Substitute.For<ILocationService>(); 
            unitTestFactory = new UnitTestFactory(r =>
            {
                r.RegisterSingleton<IPageService>(dummyPageService);
                r.RegisterSingleton<ILocationService>(dummyLocationService);
            });
            productPageViewModel = new ProductViewModel(dummyPageService, dummyLocationService, unitTestFactory);
        }


        [Test]
        public void When_we_go_to_location_page_initially_coordinates_are_empty()
        {
            
            Assert.IsTrue(String.IsNullOrWhiteSpace(productPageViewModel.Latitude));
            Assert.IsTrue(String.IsNullOrWhiteSpace(productPageViewModel.Longitude));
        }

        [Test]
        public void When_we_hit_get_location_then_location_is_displayed()
        {
            var canGetLocation = productPageViewModel.DisplayLocationCommand.CanExecute(null);
            Assert.AreEqual(true, canGetLocation);
            productPageViewModel.DisplayLocationCommand.Execute(null);

            Assert.AreEqual("1.0", productPageViewModel.Latitude);
            Assert.AreEqual("2.0", productPageViewModel.Longitude);
        }

        [Test]
        public void When_we_hit_clear_then_location_is_cleared()
        {
            
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
            Assert.AreEqual(typeof(HomePageViewModel), ((FakePageService)dummyPageService).GetViewModelPageType());
        }
    }
}

