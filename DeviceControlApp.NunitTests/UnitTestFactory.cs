using System;
using DeviceControlApp.Core.Service;
using DeviceControlApp.Core.ServiceImpln;

namespace DeviceControlApp.NunitTests
{
    public class UnitTestFactory : Factory
    {
        private readonly Action<IRegistrar> _registerAction;

        public UnitTestFactory(Action<IRegistrar> registerAction)
        {
            _registerAction = registerAction;
        }

        protected override void RegisterDependencies(IRegistrar registrar)
        {
            _registerAction.Invoke(registrar);    
        }
    }
}