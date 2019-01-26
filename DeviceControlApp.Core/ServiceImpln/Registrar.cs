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

        public IRegistrar Register<T, IT>()
        {
            _builder.RegisterType<T>().As<T>();
            return this;
        }

        public IRegistrar RegisterSingleton<T>(T t) where T:class
        {
            _builder.RegisterInstance(t).As<T>();
            return this;
        }
    }
}