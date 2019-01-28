using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceControlApp.Core.Service
{
    public interface ILocationService
    {
        Task<MyPosition> GetLocation();
        bool CheckGpsEnabled();
    }

    public class MyPosition
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
