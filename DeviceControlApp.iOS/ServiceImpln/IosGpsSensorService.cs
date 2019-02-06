using System;
using CoreLocation;
using DeviceControlApp.Core.Service;


namespace DeviceControlApp.iOS.ServiceImpln
{
    public class IosGpsSensorService: IGpsSensorService
    {
         CLLocationManager locMgr;
        public bool IsGpsEnabled()
        {
            return CLLocationManager.LocationServicesEnabled;
           // return CrossGeolocator.Current.IsGeolocationEnabled;
        }

    }
}
