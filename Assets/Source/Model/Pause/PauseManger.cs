using System;
using System.Collections.Generic;

namespace Assets.Source.Model.Pause
{
    public class PauseManger : IPauseManger
    {
        private readonly List<IPauseable> _pauseables;

        public PauseManger() => 
            _pauseables = new List<IPauseable>();

        public void Register(IPauseable pauseable) => 
            _pauseables.Add(pauseable);

        public void UnRegister(IPauseable pauseable) =>
            _pauseables.Remove(pauseable);

        public void PauseAll() => 
            _pauseables.ForEach(p => p.Pause());

        public void ResumeAll() => 
            _pauseables.ForEach(p => p.Resume());
    }
}