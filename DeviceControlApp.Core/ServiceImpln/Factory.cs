using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using DeviceControlApp.Core.Service;

namespace DeviceControlApp.Core.ServiceImpln
{
    public abstract class Factory : IFactory
    {
        private IContainer _container;

        private ContainerBuilder _builder;
        public Factory()
        {
            _builder = new ContainerBuilder();
            RegisterAllTypesInAssembly(_builder);
            RegisterFactory(_builder);
        }

        public void Initialize()
        {
            RegisterDependencies(new Registrar(_builder));
            _container = _builder.Build();
        }


        private void RegisterFactory(ContainerBuilder builder)
        {
            builder.RegisterInstance(this).As<IFactory>();
        }

        protected abstract void RegisterDependencies(IRegistrar registrar);


        private void RegisterAllTypesInAssembly(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsSelf();
        }


        

        public T Get<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
