using UnityEngine;

namespace Source
{
    public class ServiceProvider : IServiceProvider
    {
        public const string ModelUpdaterService = "Prefabs/ModelUpdater";

        public ModelUpdater GetModelUpdater() => 
            Resources.Load<ModelUpdater>(ModelUpdaterService);
    }
}