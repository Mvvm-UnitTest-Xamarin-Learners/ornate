using System;
using System.Threading.Tasks;
using Plugin.Geolocator.Abstractions;

namespace DeviceControlApp.Services
{
    public interface ILocationService
    {
        Task<MyPosition> GetLocation();
    }

    public class MyPosition
    {
        public string Latitude { get;set;}
        public string Longitude { get; set; }
    }
}
