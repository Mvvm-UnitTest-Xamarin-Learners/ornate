using System;
using System.Threading.Tasks;
using DeviceControlApp.Services;

namespace DeviceControlApp.NunitTests
{
    public class DummyLocationService:ILocationService
    {
        public async Task<MyPosition> GetLocation()
        {
            return new MyPosition()
            {
                Latitude = "1.0",
                Longitude = "2.0"
            };
        }
    }
}
