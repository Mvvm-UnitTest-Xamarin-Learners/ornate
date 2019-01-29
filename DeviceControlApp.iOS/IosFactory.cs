using DeviceControlApp.Core.Service;
using DeviceControlApp.iOS.ServiceImpln;

namespace DeviceControlApp.iOS
{
    public class IosFactory : XamarinFactory
    {
        protected override void RegisterPlatformDependencies(IRegistrar registrar)
        {
            registrar.Register<GpsService, IGpsSensor>();
        }
    }
}