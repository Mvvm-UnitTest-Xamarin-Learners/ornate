using System;
using DeviceControlApp.Core.Service;
using DeviceControlApp.ServiceImpln;


namespace DeviceControlApp.iOS.ServiceImpln
{
    public class IosGpsSensorService : IGpsSensorService
    {
        public bool IsGpsEnabled()
        {
            return GpsSensorService.IsGpsEnabled();
        }
    }
}
