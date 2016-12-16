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
            Assert.AreSame(singleton, resolver.Resolve<IService>(),
                "Multiple calls to resolve IService should return the same instance.");
        }

        protected void ResolveTransient(IComponentResolver resolver)
        {
            Guard.AgainstNull(resolver, "resolver");

            var transient = resolver.Resolve<IService>();

            Assert.IsNotNull(transient, "The requested IService implementation may not be null.");
            Assert.AreNotSame(transient, resolver.Resolve<IService>(),
                "Multiple calls to resolve IService should return unique instances.");
        }

        protected void RegisterCollection(IComponentRegistry registry)
        {
            Guard.AgainstNull(registry, "registry");

            registry.Register<IServiceDependency, ServiceDependency>(Lifestyle.Transient);

            registry.RegisterCollection(typeof (IService), new[] {typeof (Service1), typeof (Service2), typeof (Service3)},
                Lifestyle.Singleton);
        }

        protected void ResolveCollection(IComponentResolver resolver)
        {
            Guard.AgainstNull(resolver, "resolver");

            Assert.AreEqual(3, resolver.ResolveAll<IService>().Count());
        }
    }
}