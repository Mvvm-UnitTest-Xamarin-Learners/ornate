using Android.Content;
using Android.Locations;
using DeviceControlApp.Core.Service;
using Object = Java.Lang.Object;


namespace DeviceControlApp.Droid.ServiceImpln
{
    public class AndroidGpsSensorService : Object, IGpsSensorService
    {
        private readonly LocationManager _locationManager;

        public AndroidGpsSensorService()
        {
            _locationManager = (LocationManager)MainActivity.MyAppContext.GetSystemService(Context.LocationService);
        }
        public bool IsGpsEnabled()
        {
            return _locationManager.IsProviderEnabled(LocationManager.GpsProvider);
        }
    }
}
