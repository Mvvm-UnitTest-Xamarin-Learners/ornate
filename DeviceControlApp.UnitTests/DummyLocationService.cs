using System.Threading;
using System.Threading.Tasks;
using DeviceControlApp.Services;

namespace DeviceControlApp.UnitTests
{
    internal class DummyLocationService:ILocationService
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