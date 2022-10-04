using System;

namespace Assets.Source.Model.Pause
{
    public interface IPauseable
    {
        public bool IsPaused { get; }

        public void Pause();
        public void Resume();
    }
}