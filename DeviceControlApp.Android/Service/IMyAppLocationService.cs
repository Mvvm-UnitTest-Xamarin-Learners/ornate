using System;
using System.Collections.Generic;

namespace DeviceControlApp.Droid.Service
{
    public interface IMyAppLocationService
    {
        bool IsLocationTurnedOn();

        Dictionary<string, double> GetLocation();

        void StartLocationUpdates();

        void StopLocationUpdates();
    }
}
