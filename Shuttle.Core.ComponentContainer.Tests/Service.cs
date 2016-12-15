namespace Shuttle.Core.ComponentContainer.Tests
{
    public class Service : IService
    {
        public IServiceDependency ServiceDependency { get; private set; }

        public Service(IServiceDependency serviceDependency)
        {
            ServiceDependency = serviceDependency;
        }
    }
}