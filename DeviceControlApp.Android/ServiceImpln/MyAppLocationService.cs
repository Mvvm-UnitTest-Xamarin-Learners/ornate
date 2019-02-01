using System;
using System.Collections.Generic;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Content;
using DeviceControlApp.Droid.Service;

using Object = Java.Lang.Object;


namespace DeviceControlApp.Droid.ServiceImpln
{
    public class MyAppLocationService :Java.Lang.Object, IMyAppLocationService, ILocationListener
    {
        private const int TimeInterval = 1000; 
        private const int DistanceAccuracy = 10; 
        private readonly LocationManager _locationManager;
        private double _xCoordinate;
        private double _yCoordinate;

        public MyAppLocationService()
        {
            _locationManager = (LocationManager)MainActivity.MyAppContext.GetSystemService(Context.LocationService);
        }

        public bool IsLocationTurnedOn()
        {
            return _locationManager.IsProviderEnabled(LocationManager.GpsProvider);
        }

        public Dictionary<string, double> GetLocation()
        {
            return new Dictionary<string, double>
            {
                {"X co-ordinate", _xCoordinate}, {"Y co-ordinate", _yCoordinate}
            };
        }

        public void StartLocationUpdates()
        {
            //location updates would re received once in 10 seconds with 10 meters accuracy.
            _locationManager.RequestLocationUpdates(LocationManager.GpsProvider, TimeInterval, DistanceAccuracy, this);
        }

        public void StopLocationUpdates()
        {
            _locationManager.RemoveUpdates(this);
        }

        #region ILocationListener callbacks

        public void Dispose()
        {
        }

        public IntPtr Handle { get; }
        public void OnLocationChanged(Location location)
        {
            _xCoordinate = location.Latitude;
            _yCoordinate = location.Longitude;
        }

        public void OnProviderDisabled(string provider)
        {
        }

        public void OnProviderEnabled(string provider)
        {
        }

        public void OnStatusChanged(string provider, Availability status, Bundle extras)
        {
        }

        #endregion
    }
}
