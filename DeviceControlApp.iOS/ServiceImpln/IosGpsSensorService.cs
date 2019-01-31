using System;
using Plugin.Geolocator;

namespace DeviceControlApp.iOS.ServiceImpln
{
    public class IosGpsSensorService
    {
        public static bool IsGpsEnabled()
        {
            return CrossGeolocator.Current.IsGeolocationEnabled;
        }

    }
}
