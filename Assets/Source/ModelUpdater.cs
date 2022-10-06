using System.Collections.Generic;
using Source.Model;
using Source.Model.Pause;
using UnityEngine;

namespace Source
{
    public class ModelUpdater : MonoBehaviour, IPauseable
    {
        private readonly List<IUpdatable> _updatables = new List<IUpdatable>();
        private bool _isPause;

        public bool IsPaused => _isPause;

        private void Update()
        {
            if(IsPaused)
                return;

            _updatables.ForEach(updatable => updatable?.Update(Time.deltaTime));
        }

        public void Register(IUpdatable updatable) => 
            _updatables.Add(updatable);

        public void UnRegister(IUpdatable updatable) =>
            _updatables.Remove(updatable);

        public void Enable() => 
            _isPause = false;

        public void Disable() =>
            _isPause = true;

        public void Pause() => 
            _isPause = true;

        public void Resume() => 
            _isPause = false;
    }
}
