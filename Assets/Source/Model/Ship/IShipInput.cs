using System;

namespace Source.Model.Ship
{
    public interface IShipInput
    {
        public event Action FirstGunShot;
        public event Action SecondGunShot;
        public event Action Enabled;
        public event Action Disabled;

        public float Move { get; }
        public float Rotate { get; }

        public void Enable();
        public void Disable();
    }
}