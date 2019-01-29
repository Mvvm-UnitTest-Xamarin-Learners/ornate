using System;
using DeviceControlApp.Core.Service;
using Plugin.Geolocator;

namespace DeviceControlApp.iOS.ServiceImpln
{
    public class GpsService : IGpsSensor
    {
        public bool CheckGpsEnabled()
        {
            return CrossGeolocator.Current.IsGeolocationEnabled;
        }
    }
}
