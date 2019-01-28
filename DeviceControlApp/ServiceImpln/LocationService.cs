using System;
using System.Threading.Tasks;
using DeviceControlApp.Core.Service;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace DeviceControlApp.ServiceImpln
{
    public class LocationService : ILocationService
    {
        public bool CheckGpsEnabled()
        {
            return CrossGeolocator.Current.IsGeolocationEnabled;
        }

        public async Task<MyPosition> GetLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync();
            return new MyPosition()
            {
                Latitude = position.Latitude.ToString(),
                Longitude = position.Longitude.ToString(),
            };
        }
    }
}

