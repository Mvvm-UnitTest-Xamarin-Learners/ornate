using System;
using DeviceControlApp.Core.Service;
using Plugin.Geolocator;

namespace DeviceControlApp.ServiceImpln
{
    public class GpsSensorService
    {

        public static bool IsGpsEnabled()
        {
            return CrossGeolocator.Current.IsGeolocationEnabled;
        }
    }
}
