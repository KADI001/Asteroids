using System;

namespace Source.Model.Pause
{
    public interface IPauseable
    {
        public bool IsPaused { get; }

        public void Pause();
        public void Resume();
    }
}