using System;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace DeviceControlApp.Services
{
    public class LocationService : ILocationService
    {
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

