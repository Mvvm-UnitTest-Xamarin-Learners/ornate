using DeviceControlApp.Core.Service;
using DeviceControlApp.Droid.ServiceImpln;

namespace DeviceControlApp.Droid
{
    public class AndroidFactory : XamarinFactory
    {
        protected override void RegisterPlatformDependencies(IRegistrar registrar)
        {
            registrar.Register<AndroidGpsSensorService, IGpsSensorService>();
        }
    }
}