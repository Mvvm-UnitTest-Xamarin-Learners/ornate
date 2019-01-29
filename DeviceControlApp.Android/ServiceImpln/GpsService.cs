using System;
using DeviceControlApp.Core.Service;
using Plugin.Geolocator;

namespace DeviceControlApp.Droid.ServiceImpln
{
    public class GpsService : IGpsSensor
    {
        public bool CheckGpsEnabled()
        {
            return CrossGeolocator.Current.IsGeolocationEnabled;
        }
    }
}
