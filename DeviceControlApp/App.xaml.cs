﻿using System;
using DeviceControlApp.Core.Service;
using DeviceControlApp.Core.ViewModel;
using DeviceControlApp.ServiceImpln;
using DeviceControlApp.View;
using DeviceControlApp.ViewMap;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DeviceControlApp
{
    public partial class App : Application
    {
        public App(IFactory factory)
        {
            InitializeComponent();
            var homePage = new HomePage();
            homePage.BindingContext = factory.Get<HomePageViewModel>();
            MainPage = new NavigationPage(homePage);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
