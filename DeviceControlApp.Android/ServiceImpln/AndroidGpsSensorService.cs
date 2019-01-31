using System;
using DeviceControlApp.Core.Service;
using DeviceControlApp.ServiceImpln;


namespace DeviceControlApp.Droid.ServiceImpln
{
    public class AndroidGpsSensorService : IGpsSensorService
    {
        public bool IsGpsEnabled()
        {
            return GpsSensorService.IsGpsEnabled();
        }
    }
}
