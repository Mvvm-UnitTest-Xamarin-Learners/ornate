using System;
using CoreLocation;
using DeviceControlApp.Core.Service;


namespace DeviceControlApp.iOS.ServiceImpln
{
    public class IosGpsSensorService: IGpsSensorService
    {
        public bool IsGpsEnabled()
        {
            return CLLocationManager.LocationServicesEnabled;
        }

    }
}
