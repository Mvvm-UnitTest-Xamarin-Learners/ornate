﻿using System;
using System.Diagnostics;
using System.Windows.Input;
using DeviceControlApp.Core.Service;

namespace DeviceControlApp.Core.ViewModel
{
    public class LocationViewModel : BaseViewModel
    {
        public ICommand GoBackCommand { get; private set; }
        public ICommand DisplayLocationCommand { get; private set; }
        public ICommand ClearLocationCommand { get; private set; }
        public ICommand NextPageCommand { get; private set; }
        public IPageService _pageService;
        public ILocationService _locationService;
        private readonly IFactory _factory;

        private string _latitude;
        public string Latitude
        {
            get => _latitude;
            set
            {
                _latitude = value;
                NotifyPropertyChanged();
            }

        }

        private string _longitude;
        public string Longitude
        {

            get => _longitude;
            set
            {
                _longitude = value;
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

        public LocationViewModel(IPageService pageService, ILocationService locationService, IFactory factory)
        {
            _pageService = pageService;
            _locationService = locationService;
            _factory = factory;

            GoBackCommand = new RelayCommand(GoToHomePage);
            ClearLocationCommand = new RelayCommand(ClearLocation);
            DisplayLocationCommand = new RelayCommand(DisplayLocation);
            NextPageCommand = new RelayCommand(GoToLocationStatusPage);

        }

        private void ClearLocation()
        {
            Latitude = "";
            Longitude = "";
            Flag = false;
        }

        private void GoToHomePage()
        {
            _pageService.GoNext(_factory.Get<HomePageViewModel>());
        }

        private void GoToLocationStatusPage()
        {
            _pageService.GoNext(_factory.Get<GpsStatusViewModel>());
        }

        private async void DisplayLocation()
        {
            var myLocation = await _locationService.GetLocation();
            Debug.Write(myLocation.Latitude);
            Latitude = myLocation.Latitude;
            Longitude = myLocation.Longitude;
            Flag = true;
        }
    }
}