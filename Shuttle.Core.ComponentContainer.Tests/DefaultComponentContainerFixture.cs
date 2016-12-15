using NUnit.Framework;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.ComponentContainer.Tests
{
    [TestFixture]
    public class DefaultComponentContainerFixture : ComponentContainerFixture
    {
        [Test]
        public void Should_be_able_to_register_and_resolve_a_singleton()
        {
            var container = new DefaultComponentContainer();

            RegisterSingleton(container);
            ResolveSingleton(container);
        }

        [Test]
        public void Should_be_able_to_register_and_resolve_transient_components()
        {
            var container = new DefaultComponentContainer();

            RegisterTransient(container);
            ResolveTransient(container);
        }

        [Test]
        public void Should_be_able_to_register_and_resolve_a_named_singleton()
        {
            var container = new DefaultComponentContainer();

            RegisterNamedSingleton(container);
            ResolveNamedSingleton(container);
        }

        [Test]
        public void Should_be_able_to_register_and_resolve_named_transient_components()
        {
            var container = new DefaultComponentContainer();

            RegisterNamedTransient(container);
            ResolveNamedTransient(container);
        }

        [Test]
        public void Should_be_able_resolve_all_instances()
        {
            var container = new DefaultComponentContainer();

            RegisterMultipleInstances(container);
            ResolveMultipleInstances(container);
        }
    }
}