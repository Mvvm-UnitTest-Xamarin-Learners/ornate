using System;
using DeviceControlApp.Core.Service;
using Plugin.Geolocator;

namespace DeviceControlApp.iOS.ServiceImpln
{
    public class IosGpsSensorService: IGpsSensorService
    {
       
        public bool IsGpsEnabled()
        {
            return CrossGeolocator.Current.IsGeolocationEnabled;
        }

    }
}
