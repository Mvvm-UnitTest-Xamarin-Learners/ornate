using System;
using DeviceControlApp.Core.Service;
using DeviceControlApp.ServiceImpln;


namespace DeviceControlApp.Droid.ServiceImpln
{
    public class AndroidGpsSensorService : IGpsSensorService
    {
        MyAppLocationService appLocationService;
        public bool IsGpsEnabled()
        {
            appLocationService = new MyAppLocationService();
            return appLocationService.IsLocationTurnedOn();
        }
    }
}
