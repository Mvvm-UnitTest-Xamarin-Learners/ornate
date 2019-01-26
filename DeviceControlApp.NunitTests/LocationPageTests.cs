﻿using System;
using System.Threading.Tasks;
using DeviceControlApp.Core.Service;
using DeviceControlApp.Core.ViewModel;
using DeviceControlApp.Services;
using NSubstitute;
using NUnit.Framework;

namespace DeviceControlApp.NunitTests
{
    public class LocationPageTests
    {

        [Test]
        public void When_we_go_to_location_page_initally_coordinates_are_empty()
        {
            var dummyPageService = new DummyPageService();
            var dummyLocationService = new DummyLocationService();
            var homePageViewModel = new HomePageViewModel(dummyPageService, dummyLocationService);
            var canGoNext = homePageViewModel.GoToNextCommand.CanExecute(null);
            homePageViewModel.GoToNextCommand.Execute(null);
            var productPageViewModel = new ProductViewModel(dummyPageService, dummyLocationService);

            Assert.IsTrue(String.IsNullOrWhiteSpace(productPageViewModel.Latitude));
            Assert.IsTrue(String.IsNullOrWhiteSpace(productPageViewModel.Longitude));
        }

        [Test]
        public void When_we_hit_get_location_then_location_is_displayed()
        {
            var dummyPageService = new DummyPageService();
            var dummyLocationService = new DummyLocationService();
            var productPageViewModel = new ProductViewModel(dummyPageService, dummyLocationService);
            var canGetLocation = productPageViewModel.DisplayLocationCommand.CanExecute(null);
            Assert.AreEqual(true, canGetLocation);
            productPageViewModel.DisplayLocationCommand.Execute(null);

            Assert.AreEqual("1.0", productPageViewModel.Latitude);
            Assert.AreEqual("2.0", productPageViewModel.Longitude);
        }

        [Test]
        public void When_we_hit_get_location_then_location_is_displayed_using_nsubstitue()
        {

            var dummypageService = Substitute.For<IPageService>();

            var dummyLocationService = Substitute.For<ILocationService>();
            var myPosition = new MyPosition();
            myPosition.Latitude = "1.0";
            myPosition.Longitude = "2.0";
            dummyLocationService.GetLocation().Returns(Task.FromResult(myPosition));
            var productPageViewModel = new ProductViewModel(dummypageService, dummyLocationService);
            var canGetLocation = productPageViewModel.DisplayLocationCommand.CanExecute(null);
            Assert.AreEqual(true, canGetLocation);
            productPageViewModel.DisplayLocationCommand.Execute(null);

            Assert.AreEqual("1.0", productPageViewModel.Latitude);
            Assert.AreEqual("2.0", productPageViewModel.Longitude);
        }

        [Test]
        public void When_we_hit_clear_then_location_is_cleared()
        {

            var dummyPageService = new DummyPageService();
            var dummyLocationService = new DummyLocationService();
            var productPageViewModel = new ProductViewModel(dummyPageService, dummyLocationService);
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
            var dummyPageService = new DummyPageService();
            var dummyLocationService = new DummyLocationService();
            var productPageViewModel = new ProductViewModel(dummyPageService, dummyLocationService);
            var canGoBack = productPageViewModel.GoBackCommand.CanExecute(null);
            productPageViewModel.GoBackCommand.Execute(null);

            Assert.AreEqual(true, canGoBack);
            Assert.AreEqual(typeof(HomePageViewModel), dummyPageService.GetViewModelPageType());
        }
    }
}

