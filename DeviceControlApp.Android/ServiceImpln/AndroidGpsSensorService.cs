using System;
using DeviceControlApp.Core.Service;
using Plugin.Geolocator;

namespace DeviceControlApp.Droid.ServiceImpln
{
    public class AndroidGpsSensorService : IGpsSensorService
    {
        public bool IsGpsEnabled()
        {
            return CrossGeolocator.Current.IsGeolocationEnabled;
        }
    }
}
