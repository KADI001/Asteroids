using UnityEngine;

namespace Source
{
    public class ServiceFactory : IServiceFactory
    {
        private IServiceProvider _serviceProvider;

        public ServiceFactory(IServiceProvider serviceProvider) => 
            _serviceProvider = serviceProvider;

        public ModelUpdater CreateModelUpdater() => 
            Object.Instantiate(_serviceProvider.GetModelUpdater());
    }
}
