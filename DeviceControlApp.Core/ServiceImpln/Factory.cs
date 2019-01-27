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
        private readonly ContainerLazyFactory _containerLazyFactory;
        protected Factory()
        {
            var builder = new ContainerBuilder();
            RegisterAllTypesInAssembly(builder);
            RegisterFactory(builder);
            _containerLazyFactory = CreateContainerLazyFactory(builder);
        }

        private ContainerLazyFactory CreateContainerLazyFactory(ContainerBuilder builder)
        {
            var c1 = new ContainerLazyFactory(() =>
            {
                var registrar = new Registrar(builder);
                RegisterDependencies(registrar);
                return builder;
            });
            return c1;
        }

        public T Get<T>()
        {
            return _containerLazyFactory.GetContainer().Resolve<T>();
        }

        protected abstract void RegisterDependencies(IRegistrar registrar);
        

        private void RegisterFactory(ContainerBuilder builder)
        {
            builder.RegisterInstance(this).As<IFactory>();
        }
        
        private void RegisterAllTypesInAssembly(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsSelf();
        }

        private class ContainerLazyFactory
        {
            private readonly Func<ContainerBuilder> _containerBuilderFactory;
            private IContainer _container;

            public ContainerLazyFactory(Func<ContainerBuilder> containerBuilderFactory)
            {
                _containerBuilderFactory = containerBuilderFactory;
            }

            public IContainer GetContainer()
            {
                if (_container == null)
                {
                    var builder = _containerBuilderFactory.Invoke();
                    _container = builder.Build();
                }
                return _container;
            }
        }
    }
}
