using Autofac;
using DeviceControlApp.Core.Service;

namespace DeviceControlApp.Core.ServiceImpln
{
    public class Registrar : IRegistrar
    {
        private readonly ContainerBuilder _builder;

        public Registrar(ContainerBuilder builder)
        {
            _builder = builder;
        }

        public void Register<T, IT>()
        {
            _builder.RegisterType<T>().As<T>();
        }
    }
}