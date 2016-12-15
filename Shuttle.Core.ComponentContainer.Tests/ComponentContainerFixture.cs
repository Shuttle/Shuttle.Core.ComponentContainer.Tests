using System.Linq;
using NUnit.Framework;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.ComponentContainer.Tests
{
    public class ComponentContainerFixture
    {
        protected void RegisterSingleton(IComponentRegistry registry)
        {
            Guard.AgainstNull(registry, "registry");

            registry.Register<IServiceDependency, ServiceDependency>(Lifestyle.Singleton);
            registry.Register<IService, Service>(Lifestyle.Singleton);
        }

        protected void RegisterTransient(IComponentRegistry registry)
        {
            Guard.AgainstNull(registry, "registry");

            registry.Register<IServiceDependency, ServiceDependency>(Lifestyle.Transient);
            registry.Register<IService, Service>(Lifestyle.Transient);
        }

        protected void ResolveSingleton(IComponentResolver resolver)
        {
            Guard.AgainstNull(resolver, "resolver");

            var singleton = resolver.Resolve<IService>();

            Assert.IsNotNull(singleton, "The requested IService implementation may not be null.");
            Assert.AreSame(singleton, resolver.Resolve<IService>(), "Multiple calls to resolve IService should return the same instance.");
        }

        protected void ResolveTransient(IComponentResolver resolver)
        {
            Guard.AgainstNull(resolver, "resolver");

            var transient = resolver.Resolve<IService>();

            Assert.IsNotNull(transient, "The requested IService implementation may not be null.");
            Assert.AreNotSame(transient, resolver.Resolve<IService>(), "Multiple calls to resolve IService should return unique instances.");
        }

        protected void RegisterNamedSingleton(IComponentRegistry registry)
        {
            Guard.AgainstNull(registry, "registry");

            registry.Register<IServiceDependency, ServiceDependency>(Lifestyle.Singleton);
            registry.Register<IService, Service>("key-1", Lifestyle.Singleton);
        }

        protected void RegisterNamedTransient(IComponentRegistry registry)
        {
            Guard.AgainstNull(registry, "registry");

            registry.Register<IServiceDependency, ServiceDependency>(Lifestyle.Transient);
            registry.Register<IService, Service>("key-1", Lifestyle.Transient);
        }

        protected void ResolveNamedSingleton(IComponentResolver resolver)
        {
            Guard.AgainstNull(resolver, "resolver");

            var singleton = resolver.Resolve<IService>("key-1");

            Assert.IsNotNull(singleton, "The requested IService implementation may not be null.");
            Assert.AreSame(singleton, resolver.Resolve<IService>("key-1"), "Multiple calls to resolve IService should return the same instance.");
        }

        protected void ResolveNamedTransient(IComponentResolver resolver)
        {
            Guard.AgainstNull(resolver, "resolver");

            var transient = resolver.Resolve<IService>("key-1");

            Assert.IsNotNull(transient, "The requested IService implementation may not be null.");
            Assert.AreNotSame(transient, resolver.Resolve<IService>("key-1"), "Multiple calls to resolve IService should return unique instances.");
        }

        protected void RegisterMultipleInstances(IComponentRegistry registry)
        {
            Guard.AgainstNull(registry, "registry");

            registry.Register<IServiceDependency, ServiceDependency>(Lifestyle.Transient);
            registry.Register<IService, Service>("key-1", Lifestyle.Singleton);
            registry.Register<IService, Service>("key-2", Lifestyle.Singleton);
            registry.Register<IService, Service>("key-3", Lifestyle.Singleton);
        }

        protected void ResolveMultipleInstances(IComponentResolver resolver)
        {
            Guard.AgainstNull(resolver, "resolver");

            Assert.AreEqual(3, resolver.ResolveAll<IService>().Count());
        }
    }
}
