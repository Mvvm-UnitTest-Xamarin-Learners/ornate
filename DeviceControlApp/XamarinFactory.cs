using System;
using System.Collections.Generic;
using System.Text;
using DeviceControlApp.Core.Service;
using DeviceControlApp.Core.ServiceImpln;
using DeviceControlApp.ServiceImpln;
using DeviceControlApp.ViewMap;

namespace DeviceControlApp
{
    public abstract class XamarinFactory : Factory
    {
        protected override void RegisterDependencies(IRegistrar registrar)
        {
            RegisterXamarinDependencies(registrar);
            RegisterPlatformDependencies(registrar);
        }

        private void RegisterXamarinDependencies(IRegistrar registrar)
        {
            registrar.Register<LocationService, ILocationService>();
            registrar.Register<PageService, IPageService>();
        }

        protected abstract void RegisterPlatformDependencies(IRegistrar registrar);

    }
}
